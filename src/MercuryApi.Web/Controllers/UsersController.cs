using MercuryApi.Data.DataAccessLayer.Users;
using MercuryApi.Data.Models;
using MercuryApi.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MercuryApi.Web.Controllers
{
    public sealed class UsersController : BaseController<UsersController>
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository,
            ILogger<UsersController> logger)
            : base(logger)
        {
            _usersRepository = usersRepository;
        }

        // Users/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserViewModel userViewModel)
        {
            try
            {
                var user = new User
                {
                    Id = Guid.Parse(userViewModel.Id),
                    Platform = userViewModel.Platform
                };

                await _usersRepository.CreateNewUser(user);
                return Ok(userViewModel);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }
    }
}