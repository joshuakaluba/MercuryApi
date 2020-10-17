using MercuryApi.Data.DataContext;
using MercuryApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MercuryApi.Data.DataAccessLayer.Users
{
    public class UsersRepository : IUsersRepository
    {
        public async Task CreateNewUser(User user)
        {
            using (var db = new MercuryDataContext())
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
            }
        }

        public async Task<User> FindUser(Guid id)
        {
            using (var db = new MercuryDataContext())
            {
                var user
                     = await db.Users
                         .Where(m => m.Id == id)
                            .FirstOrDefaultAsync();
                return user;
            }
        }
    }
}