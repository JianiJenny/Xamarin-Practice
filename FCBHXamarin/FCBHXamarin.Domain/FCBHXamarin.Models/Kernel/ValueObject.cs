using System;
using Newtonsoft.Json;

namespace FCBHXamarin.Models.Kernel
{
    /// <summary>
    /// Provides common functionality for DDD value objects.
    /// </summary>
    public abstract class ValueObject
    {
        [JsonProperty("EquivalenceValue")]
        public Guid EquivalenceValue { get; private set; } = Guid.NewGuid();
    }
}
