using MercuryApi.Data.Enums;
using System;

namespace MercuryApi.Data.Models
{
    public class User : Auditable
    {
        public User()
        {
        }

        public User(Guid id, int platform)
        {
            Id = id;
            Platform = (PlatformEnum)platform;
        }

        public PlatformEnum Platform { get; set; }
    }
}