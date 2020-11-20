using MercuryApi.Data.Models;
using MercuryApi.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercuryApi.Data.DataAccessLayer.Sessions
{
    public interface ISessionsRepository
    {
        Task AddUserToSession(User user, Session session);

        Task CreateSession(Session session);

        Task DeleteSession(Session session);

        Task<Session> GetSession(Guid sessionId);

        Task<Session> GetSessionByShortSessionCode(string sessionCode);

        Task<IEnumerable<Session>> GetSessionsByUser(User user);

        Task RemoveUserFromSession(User user, Session session);

        Task UpdateSession(Session session);

        Task<Session> UpdateSessionCount(SessionOperationViewModel sessionOperationViewModel);
    }
}