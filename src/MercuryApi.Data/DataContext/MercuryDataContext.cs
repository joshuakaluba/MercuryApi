using MercuryApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MercuryApi.Data.DataContext
{
    public sealed class MercuryDataContext : DbContext
    {
        internal DbSet<User> Users { get; set; }
        internal DbSet<Session> Sessions { get; set; }
        internal DbSet<UserSession> UserSessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString
                = $"Server={ApplicationConfig.DatabaseHost};" +
                    $"database={ApplicationConfig.DatabaseName};" +
                        $"uid={ApplicationConfig.DatabaseUser};" +
                            $"pwd={ApplicationConfig.DatabasePassword};" +
                                "pooling=true;";

            optionsBuilder.UseMySql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSession>()
                .HasKey(c => new { c.SessionId, c.UserId });
        }
    }
}