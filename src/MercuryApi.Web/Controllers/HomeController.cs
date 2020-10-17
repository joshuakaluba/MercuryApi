using MercuryApi.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace MercuryApi.Web.Controllers
{
    public sealed class HomeController : BaseController<HomeController>
    {
        public HomeController(ILogger<HomeController> logger)
            : base(logger)
        {
        }

        // Home/Index
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Home/Download
        [HttpGet]
        public IActionResult Download()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}