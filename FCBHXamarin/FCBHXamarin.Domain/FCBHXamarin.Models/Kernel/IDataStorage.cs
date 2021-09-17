using System;
using Newtonsoft.Json;

namespace FCBHXamarin.Models.Kernel
{
    public interface IDataStorage
    {
        [JsonProperty("DateUpdated")]
        DateTimeOffset DateUpdated { get; }

        [JsonProperty("Type")]
        string Type { get; }
    }
}
