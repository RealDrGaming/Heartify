using Heartify.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Heartify.Controllers
{
	[AllowAnonymous]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> _logger)
        {
            logger = _logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }

        public IActionResult FAQs()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }
    }
}