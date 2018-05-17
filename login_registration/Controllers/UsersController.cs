using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using login_registration.Models;
using DbConnection;

namespace login_registration.Controllers
{
    public class UsersController : Controller
    {

        [HttpGet]
        [Route("")]
        public IActionResult Register()
        {
            ViewBag.errors = "";

            return View();
        }

        [HttpPost]
        [Route("process-register")]
        public IActionResult ProcessRegister(User model, string Password_Confirm) {

            string Search = $"SELECT * FROM Users WHERE email = '{model.Email}'";
            var Result = DbConnector.Query(Search);

            if (Result.Count == 0) {

                if (Password_Confirm == model.Password) {
                    
                    if(ModelState.IsValid) {
                        
                        string newUser = $"INSERT INTO Users (first_name, last_name, email, password) VALUES ('{model.First_Name}', '{model.Last_Name}', '{model.Email}', '{model.Password}')";
                        DbConnector.Execute(newUser);
                        
                        return RedirectToAction("Home");
                    }
                    return View("Register",model);
                }
                else {
                    TempData["error"] = "Passwords do not match.";
                    return View("Register");
                }
            }

            else {
                TempData["error"] = "A user has already registered with that email address.";
                return View("Register");
            }
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [Route("process-login")]
        public IActionResult Process(string email, string password) {

            string Search = $"SELECT * FROM Users WHERE email = '{email}' and password = '{password}'";
            var Result = DbConnector.Query(Search);

            if (Result.Count == 1) {
                Console.WriteLine("found it");
                Console.WriteLine(Result[0]);
                
                return RedirectToAction("Home");
            }
            TempData["error"] = "Invalid login info";
            return View("Login");
        }

        [HttpGet]
        [Route("home")]
        public IActionResult Home() {
            return View();
        }

        [HttpGet]
        [Route("about")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
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
