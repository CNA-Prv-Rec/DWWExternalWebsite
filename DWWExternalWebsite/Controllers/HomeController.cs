using DWWExternalWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DWWExternalWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Index");

            _logger.LogInformation("Index: " + Request.HttpContext.Connection.RemoteIpAddress.ToString());
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Privacy: " + Request.HttpContext.Connection.RemoteIpAddress.ToString());
            return View();
        }

        public IActionResult eCompete()
        {
            _logger.LogInformation("eCompete");
            _logger.LogInformation("eCompete: " + Request.HttpContext.Connection.RemoteIpAddress.ToString());
            return View();
        }

        public IActionResult Services()
        {
            _logger.LogInformation("Services");
            _logger.LogInformation("Services: " + Request.HttpContext.Connection.RemoteIpAddress.ToString());
            return View();
        }
        public IActionResult Technologies()
        {
            _logger.LogInformation("Technologies");
            _logger.LogInformation("Technologies: " + Request.HttpContext.Connection.RemoteIpAddress.ToString());
            return View();
        }
        public IActionResult Careers()
        {
            _logger.LogInformation("Careers: " + Request.HttpContext.Connection.RemoteIpAddress.ToString());
          
            return View();
        }
        public IActionResult About()
        {
            _logger.LogInformation("About");
            _logger.LogInformation("About: " + Request.HttpContext.Connection.RemoteIpAddress.ToString());
            return View();
        }
        public IActionResult Contact()
        {
            _logger.LogInformation("Contact: "+ Request.HttpContext.Connection.RemoteIpAddress.ToString());
            return View();
        }
        public IActionResult ThankYou()
        {
            _logger.LogInformation("ThankYou: " + Request.HttpContext.Connection.RemoteIpAddress.ToString());
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            
            _logger.LogError("Error: " + Request.HttpContext.Connection.RemoteIpAddress.ToString() + Activity.Current?.Id ?? HttpContext.TraceIdentifier);
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}