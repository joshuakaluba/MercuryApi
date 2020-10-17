using MercuryApi.Data.DataContext;
using MercuryApi.Data.Enums;
using MercuryApi.Data.Models;
using MercuryApi.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercuryApi.Data.DataAccessLayer.Sessions
{
    public class SessionsRepository : ISessionsRepository
    {
        public async Task AddUserToSession(User user, Session session)
        {
            using (var db = new MercuryDataContext())
            {
                var existingUserSession
                    = await db.UserSessions
                        .Where(s => s.UserId == user.Id && s.SessionId == session.Id)
                            .FirstOrDefaultAsync();

                if (existingUserSession != null)
                {
                    return;
                }

                var sessionUser = new UserSession
                {
                    UserId = user.Id,
                    SessionId = session.Id
                };

                db.UserSessions.Add(sessionUser);
                await db.SaveChangesAsync();
            }
        }

        public async Task CreateSession(Session session)
        {
            using (var db = new MercuryDataContext())
            {
                db.Sessions.Add(session);
                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteSession(Session session)
        {
            using (var db = new MercuryDataContext())
            {
                db.Sessions.Remove(session);
                await db.SaveChangesAsync();
            }
        }

        public async Task<Session> GetSession(Guid sessionId)
        {
            using (var db = new MercuryDataContext())
            {
                var session
                     = await db.Sessions
                         .Where(m => m.Id == sessionId)
                            .FirstOrDefaultAsync();
                return session;
            }
        }

        public async Task<Session> GetSessionByShortSessionCode(string sessionCode)
        {
            using (var db = new MercuryDataContext())
            {
                var session
                     = await db.Sessions
                         .Where(m => m.ShortSessionCode.ToUpper() == sessionCode.ToUpper())
                            .FirstOrDefaultAsync();
                return session;
            }
        }

        public async Task<IEnumerable<Session>> GetSessionsByUser(User user)
        {
            using (var db = new MercuryDataContext())
            {
                var sessions
                    = await db.UserSessions
                    .Where(s => s.UserId == user.Id)
                        .Include(m => m.Session).Select(m => m.Session)
                            .OrderByDescending(session => session.DateModified)
                                .ToListAsync();

                /*
                 var monitors =
                    await db.Monitors
                        .Where(monitor => monitor.ApplicationUserId == user.Id)
                            .OrderByDescending(monitor => monitor.DateCreated)
                                .ToListAsync();
                 */
                return sessions;
            }
        }

        public async Task UpdateSession(Session session)
        {
            using (var db = new MercuryDataContext())
            {
                db.Sessions.Update(session);
                await db.SaveChangesAsync();
            }
        }

        public async Task<Session> UpdateSessionCount(SessionOperationViewModel sessionOperationViewModel)
        {
            using (var db = new MercuryDataContext())
            {
                var session
                     = await db.Sessions
                         .Where(m => m.Id == sessionOperationViewModel.SessionId)
                            .FirstOrDefaultAsync();

                switch (sessionOperationViewModel.SessionOperation)
                {
                    case SessionOperationEnum.INCREMENT:
                        session.CurrentCount = session.CurrentCount + 1;
                        break;

                    case SessionOperationEnum.DECREMENT:
                        var count = session.CurrentCount - 1;
                        session.CurrentCount = count >= 0 ? count : 0;
                        break;

                    default: break;
                }

                session.DateModified = DateTime.UtcNow;

                db.Sessions.Update(session);
                await db.SaveChangesAsync();

                return session;
            }
        }
    }
}