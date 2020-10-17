using Newtonsoft.Json;
using System;

namespace MercuryApi.Data.ViewModels
{
    public sealed class SessionViewModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("capacity")]
        public int Capacity { get; set; }

        [JsonProperty("userId")]
        public Guid UserId { get; set; }
    }
}