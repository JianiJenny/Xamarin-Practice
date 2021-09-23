using FCBHXamarinMy.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FCBHXamarinMy.Services
{
    public class DigitalBiblePlatformService
    {
        private static string _licenseKey = "2ea095ec-b158-a671-b8fa-32312d3ad62f";
        private static string rootUri = "b4.dbt.io";
        private WebCommunicationService _webService;

        public DigitalBiblePlatformService()
        {
            _webService = new WebCommunicationService();
        }

        public async Task<BibleVersion> GetDBPCatalogAsync(CancellationToken cancellationToken)
        {
            var xml = await _webService.GetWebContentAsync($"http://{rootUri}/api/bibles?format=xml&key={_licenseKey}&v=4", cancellationToken);
            

            ParseCatalog(xml);
        }

        private List<BibleVersion> ParseCatalog(string xml)
        {
            var list = new List<BibleVersion>();

            var xDoc = XDocument.Parse(xml);


        }
    }
}