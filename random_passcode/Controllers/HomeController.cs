using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
 
namespace random_passcode.Controllers
{
    public class HomeController : Controller
    {
        bool temp = false;
        string passcode = "";

        


        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {   
            if (HttpContext.Session.GetInt32("passcodeNum") == null) {
                HttpContext.Session.SetInt32("passcodeNum", 0);
            }

            if (temp == true) {
                passcode = TempData["Passcode"] as string;
                System.Console.WriteLine(passcode);
            }

            ViewBag.Count = HttpContext.Session.GetInt32("passcodeNum");

            return View();
        }
      
        [HttpPost]
        [Route("generate")]
        public IActionResult Generate() {

            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            string password = "";

            Random rand = new Random();

            for (int i = 0; i < 14; i++) {
                password += characters[rand.Next(0,characters.Length - 1)];
            }


            TempData["Passcode"] = (string)password;
            int? passcodeNum = HttpContext.Session.GetInt32("passcodeNum");
            passcodeNum++;
            HttpContext.Session.SetInt32("passcodeNum", (int)passcodeNum);

            return RedirectToAction("Index");
        }
    }
}