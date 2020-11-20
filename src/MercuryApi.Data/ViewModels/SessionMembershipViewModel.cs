using Newtonsoft.Json;
using System;

namespace MercuryApi.Data.ViewModels
{
    public sealed class SessionMembershipViewModel
    {
        [JsonProperty("userId")]
        public Guid UserId { get; set; }

        [JsonProperty("sessionId")]
        public Guid SessionId { get; set; }

        [JsonProperty("sessionCode")]
        public string SessionCode { get; set; }
    }
}