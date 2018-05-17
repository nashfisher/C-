using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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
            // Setting default nav link to login, should change after login
            HttpContext.Session.SetString("Log", "Login");
            string Log = HttpContext.Session.GetString("Log");
            ViewBag.log = Log;

            ViewBag.errors = "";

            return View();
        }

        [HttpPost]
        [Route("process-register")]
        public IActionResult ProcessRegister(User model, string Password_Confirm) {

            // Checking to see if user has already registered
            string Search = $"SELECT * FROM Users WHERE email = '{model.Email}'";
            var Result = DbConnector.Query(Search);

            // If user is not registered, proceed
            if (Result.Count == 0) {

                // Do passwords match?
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

            // If user already registered, error
            else {
                TempData["error"] = "A user has already registered with that email address.";
                return View("Register");
            }
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            string Log = HttpContext.Session.GetString("Log");
            ViewBag.log = Log;

            return View("Login");
        }

        [HttpPost]
        [Route("process-login")]
        public IActionResult Process(string email, string password) {

            string Search = $"SELECT * FROM Users WHERE email = '{email}' and password = '{password}'";
            var Result = DbConnector.Query(Search);

            if (Result.Count == 1) {
                Console.WriteLine("found it");

                HttpContext.Session.Clear();
                HttpContext.Session.SetString("Log", email);
                
                return RedirectToAction("Home");
            }
            TempData["error"] = "Invalid login info";
            return View("Login");
        }

        [HttpGet]
        [Route("home")]
        public IActionResult Home() {

            string Log = HttpContext.Session.GetString("Log");
            ViewBag.log = Log;

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
