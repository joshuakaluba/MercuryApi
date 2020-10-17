using MercuryApi.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace MercuryApi.Web.Controllers
{
    public abstract class BaseController<T> : Controller
    {
        protected ILogger<T> Logger;

        protected BaseController(ILogger<T> logger)
        {
            Logger = logger;
        }

        protected IActionResult HandleError(Exception ex)
        {
            Logger.LogError(ex.Message);
            return BadRequest(new ErrorMessage(ex));
        }
    }
}