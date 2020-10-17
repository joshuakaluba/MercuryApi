using Newtonsoft.Json;
using System;

namespace MercuryApi.Data.Models
{
    public abstract class Auditable : IEquatable<Auditable>
    {
        [JsonProperty("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [JsonProperty("dateCreated")]
        public virtual DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [JsonProperty("dateModified")]
        public virtual DateTime DateModified { get; set; } = DateTime.UtcNow;

        public virtual bool Equals(Auditable other)
        {
            return Id == other.Id;
        }
    }
}