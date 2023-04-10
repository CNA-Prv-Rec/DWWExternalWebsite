using DWWExternalWebsite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Json;

namespace DWWExternalWebsite.Controllers
{
    public class ContactController : Controller
    {

        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;   
        }

        // GET: ContactController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ContactController/Details/5
        public ActionResult Details(int id)
        {
            _logger.LogInformation("ContactDetails: " + Request.HttpContext.Connection.RemoteIpAddress.ToString());

            return View();
        }

        // GET: ContactController/Create
        public ActionResult Create()
        {
            _logger.LogInformation("ContactCreate: " + Request.HttpContext.Connection.RemoteIpAddress.ToString());

            return View();
        }

        // POST: ContactController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] Contact contact)
        {
            try
            {
                _logger.LogInformation("ContactPost: " + Request.HttpContext.Connection.RemoteIpAddress.ToString());


                var connectionString = Environment.GetEnvironmentVariable("CUSTOMCONNSTR_DBConnection");
                var settings = MongoClientSettings.FromConnectionString(connectionString);
             
                    var client = new MongoClient(settings);
                  //  client.StartSessionAsync().Wait();

                    var database = client.GetDatabase("dbDWWExt");
                    var dbcoll = database.GetCollection<BsonDocument>("ContactForms");

                   var data= contact.ToBsonDocument();
                    await dbcoll.InsertOneAsync(data);
           

                return RedirectToAction("ThankYou","Home");

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return View();
            }
        }

        // GET: ContactController/Edit/5
        public ActionResult Edit(int id)
        {
            _logger.LogInformation("ContactEdit: " + Request.HttpContext.Connection.RemoteIpAddress.ToString());

            return View();
        }

        // POST: ContactController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            _logger.LogInformation("ContactEdit(id): " + Request.HttpContext.Connection.RemoteIpAddress.ToString());

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
