using MercuryApi.Data.DataAccessLayer.Sessions;
using MercuryApi.Data.DataAccessLayer.Users;
using MercuryApi.Data.Models;
using MercuryApi.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MercuryApi.Web.Controllers
{
    public sealed class SessionsController : BaseController<SessionsController>
    {
        private readonly ISessionsRepository _sessionsRepository;
        private readonly IUsersRepository _usersRepository;

        public SessionsController(ISessionsRepository sessionsRepository,
            IUsersRepository usersRepository,
            ILogger<SessionsController> logger)
            : base(logger)
        {
            _sessionsRepository = sessionsRepository;
            _usersRepository = usersRepository;
        }

        // Sessions/GetSession
        [HttpGet]
        public async Task<IActionResult> GetSession(string id)
        {
            try
            {
                var session = await _sessionsRepository.GetSession(Guid.Parse(id));

                return Ok(session);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        // Sessions/GetSessionsByUserId
        [HttpGet]
        public async Task<IActionResult> GetSessionsByUserId(string id)
        {
            try
            {
                var user = await _usersRepository.FindUser(Guid.Parse(id));

                if (user != null)
                {
                    var sessions = await _sessionsRepository.GetSessionsByUser(user);

                    return Ok(sessions);
                }

                // This will only happen if the user still hasnt persisted by the time the new client requests for a session
                // The will have no sessions anyways at this point

                return Ok(id);
                
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        // Sessions/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SessionViewModel sessionViewModel)
        {
            try
            {
                var session = new Session
                {
                    Capacity = sessionViewModel.Capacity,
                    Name = sessionViewModel.Name
                };

                var shortSessionCode = session.Id.ToString().Replace("-", "").Substring(0, 8).ToUpper();
                session.ShortSessionCode = shortSessionCode;

                var user = await _usersRepository.FindUser(sessionViewModel.UserId);

                if (user != null)
                {
                    await _sessionsRepository.CreateSession(session);

                    await _sessionsRepository.AddUserToSession(user, session);

                    return Ok(session);
                }
                else
                {
                    return BadRequest(new ErrorMessage("Unable to create session"));
                }
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        // Sessions/JoinSession
        [HttpPost]
        public async Task<IActionResult> JoinSession([FromBody] JoinSessionViewModel joinSessionViewModel)
        {
            try
            {
                var user = await _usersRepository.FindUser(joinSessionViewModel.UserId);

                var session = await _sessionsRepository.GetSessionByShortSessionCode(joinSessionViewModel.SessionCode);

                if (user != null && session != null)
                {
                    await _sessionsRepository.AddUserToSession(user, session);
                    return Ok(session);
                }
                else
                {
                    return BadRequest(new ErrorMessage("Unable to join session"));
                }
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        // Sessions/UpdateCount
        [HttpPost]
        public async Task<IActionResult> UpdateCount([FromBody] SessionOperationViewModel sessionOperationViewModel)
        {
            try
            {
                var session
                    = await _sessionsRepository
                        .UpdateSessionCount(sessionOperationViewModel);

                return Ok(session);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        // Sessions/UpdateSession
        [HttpPut]
        public async Task<IActionResult> UpdateSession(Guid id, [FromBody] SessionViewModel sessionViewModel)
        {
            try
            {
                var session
                    = await _sessionsRepository.GetSession(id);

                session.Capacity = sessionViewModel.Capacity;
                session.CurrentCount = sessionViewModel.CurrentCount;
                session.Name = sessionViewModel.Name;

                await _sessionsRepository.UpdateSession(session);

                return Ok(session);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }
    }
}