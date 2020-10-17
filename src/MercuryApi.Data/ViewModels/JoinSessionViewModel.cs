﻿using Newtonsoft.Json;
using System;

namespace MercuryApi.Data.ViewModels
{
    public sealed class JoinSessionViewModel
    {
        [JsonProperty("userId")]
        public Guid UserId { get; set; }

        [JsonProperty("sessionCode")]
        public string SessionCode { get; set; }
    }
}