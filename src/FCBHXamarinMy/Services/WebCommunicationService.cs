using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using Polly.Timeout;

namespace FCBHXamarinMy.Services
{
    public class WebCommunicationService : IWebCommunicationService
    {
        // Best practice is to have a single client that is used throughout the life of the app
        private static readonly HttpClient HttpClient = new HttpClient();

        // Governs how many a retries are done, and the intervals between retries
        private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy;

        // Governs how long to give a try before giving up
        private readonly AsyncTimeoutPolicy _timeoutPolicy;

        /// <summary>
        /// Gets the response from the web
        /// </summary>
        /// <param name="url">The URL to which to make the request.</param>
        /// <param name="cancel">Allows the request to be canceled in response to a user request for cancellation</param>
        /// <returns></returns>
        private async Task<HttpResponseMessage> GetResponseAsync(string url, CancellationToken cancel)
        {
            return await _retryPolicy
                .WrapAsync(_timeoutPolicy)
                .ExecuteAsync(async () =>
                {
                    var response = await HttpClient.GetAsync(url, cancel);
                    response.EnsureSuccessStatusCode();
                    return response;
                });
        }

        /// <summary>
        /// Retrieves a string response from a web Get request to a specific url.
        /// </summary>
        /// <param name="url">The URL to which to make the request.</param>
        /// <param name="cancel">Allows the request to be canceled in response to a user request for cancellation</param>
        /// <returns>
        /// The requested string data, or an empty string if unable to fulfill the request.
        /// </returns>
        public async Task<string> GetWebContentAsync(string url, CancellationToken cancel)
        {
            try
            {
                var response = await GetResponseAsync(url, cancel);
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Constructs a new instance of the <see cref="WebCommunicationService"/> class.
        /// </summary>
        public WebCommunicationService()
        {
            // Do retries only for transient errors, at 2, 4, 8 and 16 seconds; then give up
            _retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(4, iAttempt => TimeSpan.FromSeconds(Math.Pow(2, iAttempt)));

            // 10 seconds seems to be a safe amount of time to wait in the poor Internet situations we encounter
            _timeoutPolicy = Policy
                .TimeoutAsync(TimeSpan.FromSeconds(10), TimeoutStrategy.Optimistic);
        }
    }

    public interface IWebCommunicationService
    {
        Task<string> GetWebContentAsync(string url, CancellationToken cancel);
    }
}