using System;
using Newtonsoft.Json;

namespace FCBHXamarinMy.Models.Kernel
{
    public interface IProjectIdSyncFilter
    {
        [JsonProperty("ProjectId")]
        public Guid ProjectId { get; }
    }
}
