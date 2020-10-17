using MercuryApi.Data.Enums;
using Newtonsoft.Json;

namespace MercuryApi.Data.ViewModels
{
    public sealed class UserViewModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("platform")]
        public PlatformEnum Platform { get; set; }
    }
}