using System;

namespace MercuryApi.Data.Models
{
    internal sealed class UserSession
    {
        public Guid SessionId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public Session Session { get; set; }
        public User User { get; set; }
    }
}