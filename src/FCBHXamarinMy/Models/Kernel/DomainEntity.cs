using System;
using Newtonsoft.Json;

namespace FCBHXamarinMy.Models.Kernel
{
    public class DomainEntity : IDomainEntity, IDataStorage
    {
        [JsonProperty("Id")]
        public Guid Id { get; private set; }

        /// <summary>
        /// Data persistence automatically sets this as the time of upsert, used for conflict resolution
        /// </summary>
        [JsonProperty("DateUpdated")]
        public DateTimeOffset DateUpdated { get; private set; }

        /// <summary>
        /// Couchbase needs the type of the document in order to properly find and instantiate it
        /// </summary>
        [JsonProperty("Type")]
        public string Type { get; private set; }

        /// <summary>
        /// The Document Version indicates any change in the data model. By default, Couchbase overwrites
        /// documents; which means that a early version of a document would overwrite an trash a later
        /// version's new properties. Instead, if we detect a lower version number, we do a merge, so that
        /// those properties are preserved. This allows both upward and backward compatibility of documents;
        /// and thus gives us migration. Since merging takes longer, we don't want to call it all the time.
        /// Thus this DocumentVersion mechanism is essentially an optimization; of merging when we must, but
        /// avoiding it when we can.
        /// </summary>
        [JsonProperty("DocumentVersion")]
        public int DocumentVersion { get; private set;}

        protected DomainEntity(int documentVersion)
        {
            Id = Guid.NewGuid();
            DateUpdated = DateTimeOffset.UtcNow;
            DocumentVersion = documentVersion;

            // GetType returns the instantiated type, that is, the type of the subclass
            Type = GetType().Name;
        }

        public void UpdateDateUpdated()
        {
            DateUpdated = DateTimeOffset.UtcNow;
        }

        //You MUST set this value in the constructor of a model in order for not-migration to work
        [JsonIgnore]
        public int DomainEntityVersion { get; set; }
    }
}
