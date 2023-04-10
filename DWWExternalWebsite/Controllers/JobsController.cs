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
            _logger.LogInformation("Index: " + Request.HttpContext.Connection.RemoteIpAddress.ToString());
            return View();
        }

        public IActionResult DevOpsEngineer()
        {
            _logger.LogInformation("DevOpsEngineer: " + Request.HttpContext.Connection.RemoteIpAddress.ToString());

            return View();
        }

        public IActionResult SalesAccountManager()
        {
            _logger.LogInformation("SalesAccountManager: " + Request.HttpContext.Connection.RemoteIpAddress.ToString());

            return View();
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}