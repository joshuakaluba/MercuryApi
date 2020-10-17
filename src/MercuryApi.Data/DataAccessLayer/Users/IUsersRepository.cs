using MercuryApi.Data.Models;
using System;
using System.Threading.Tasks;

namespace MercuryApi.Data.DataAccessLayer.Users
{
    public interface IUsersRepository
    {
        Task CreateNewUser(User user);

        Task<User> FindUser(Guid id);
    }
}