using MercuryApi.Data.Enums;
using Newtonsoft.Json;
using System;

namespace MercuryApi.Data.ViewModels
{
    public class SessionOperationViewModel
    {
        [JsonProperty("sessionId")]
        public Guid SessionId { get; set; }

        [JsonProperty("sessionOperation")]
        public SessionOperationEnum SessionOperation { get; set; }
    }
}