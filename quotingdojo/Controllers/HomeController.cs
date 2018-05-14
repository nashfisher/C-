using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using quotingdojo.Models;
using DbConnection;

namespace quotingdojo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("quotes")]
        
        public IActionResult Submit(string name, string comment) {

            // string name = name;
            // string comment = comment;
            string createdComment = $"INSERT INTO Quotes (name,quote,created_at) VALUES ('{name}', '{comment}', NOW())";
            DbConnector.Execute(createdComment);

            return RedirectToAction("Quotes");
        }
        
        [HttpGet]
        [Route("quotes")]
        
        public IActionResult Quotes() {

            var AllQuotes = DbConnector.Query("SELECT * FROM Quotes");

            ViewBag.Quotes = AllQuotes;

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
