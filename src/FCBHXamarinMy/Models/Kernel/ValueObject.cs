using System;
using Newtonsoft.Json;

namespace FCBHXamarinMy.Models.Kernel
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
