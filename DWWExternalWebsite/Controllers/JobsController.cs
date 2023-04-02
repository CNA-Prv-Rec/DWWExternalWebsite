using DWWExternalWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DWWExternalWebsite.Controllers
{
    public class JobsController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public JobsController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DevOpsEngineer()
        {
            return View();
        }

        public IActionResult SalesAccountManager()
        {
            return View();
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}