using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using form_submission.Models;

namespace form_submission.Controllers
{
    public class UserController : Controller
    {

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("process")]
        public IActionResult Process(string first_name, string last_name, int age, string email, string password)
        {
            User NewUser = new User {
                First_Name = first_name,
                Last_Name = last_name,
                Age = age,
                Email = email,
                Password = password
            };

            if (TryValidateModel(NewUser) == true) {
                return RedirectToAction("Success");
            }
            else {
                @ViewBag.errors = ModelState.Values;
                return View("Index");
            }

            
        }

        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
