using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
 
namespace dododachi.Controllers
{
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
    public class HomeController : Controller
    {
        class Dojodachi {
            public int happiness = 20;
            public int fullness = 20;
            public int energy = 50;
            public int meals = 3;
            Random rand = new Random();

            public string Feed() {
                if (this.meals > 0) {
                    
                    this.meals -= 1;
                    this.fullness += this.rand.Next(5,11);

                    if (this.fullness > 100 && this.happiness > 100 && this.energy > 100) {
                        return("you win");
                    }

                    return("fed dachi");
                }
                return("cannot sleep without meals");
            }

            public string Play() {
                if (this.energy >= 5) {

                    this.energy -= 5;
                    this.happiness += this.rand.Next(5,11);

                    if (this.happiness > 100 && this.fullness > 100 && this.energy > 100) {
                        return("you win");
                    }

                    return("played with dachi");
                }
                return("dachi does not have the energy to play");
            }

            public string Work() {
                if (this.energy >= 5) {

                    this.energy -= 5;
                    this.meals += this.rand.Next(1,4);

                    return("you made your pet work for food");
                }
                return("your pet doesn't have enough energy to work for food");
            }

            public string Sleep() {
                
                this.energy += 15;
                this.happiness -= 5;
                this.fullness -= 5;

                if (this.happiness > 100 && this.energy > 100 && this.fullness > 100) {
                    return("you win");
                }

                if (this.happiness <= 0 || this.fullness <= 0) {
                    return("dachi dead");
                }

                return("dachi went to sleep");
            }
        }

	    [HttpGet]
        [Route("")]
        public IActionResult Index()
        {   
            if (HttpContext.Session.GetInt32("dachimade") == null) {
                Dojodachi dachi = new Dojodachi();
                HttpContext.Session.SetObjectAsJson("dachi", dachi);
                HttpContext.Session.SetInt32("dachimade", 1);
            }
            
            Dojodachi Dachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("dachi");

            ViewBag.energy = Dachi.energy;
            ViewBag.happiness = Dachi.happiness;
            ViewBag.fullness = Dachi.fullness;
            ViewBag.meals = Dachi.meals;

            if (Dachi.fullness <= 0 || Dachi.happiness <= 0) {
                return RedirectToAction("Loss");
            }

            if (Dachi.happiness > 100 && Dachi.fullness > 100 && Dachi.energy > 100) {
                return RedirectToAction("Win");
            }

            ViewBag.message = HttpContext.Session.GetString("message");

            return View();
        }

        [HttpPost]
        [Route("play")]
        public IActionResult Play() {
            

            Dojodachi Dachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("dachi");

            Dachi.Play();

            HttpContext.Session.SetObjectAsJson("dachi", Dachi); 
            HttpContext.Session.SetString("message", "You played with Dachi");

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("feed")]
        public IActionResult Feed() {

            Dojodachi Dachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("dachi");

            Dachi.Feed();

            HttpContext.Session.SetObjectAsJson("dachi", Dachi);
            HttpContext.Session.SetString("message", "You fed Dachi");

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("work")]
        public IActionResult Work() {

            Dojodachi Dachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("dachi");

            Dachi.Work();

            HttpContext.Session.SetObjectAsJson("dachi", Dachi);
            HttpContext.Session.SetString("message", "You made Dachi work for food");

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("sleep")]
        public IActionResult Sleep() {

            Dojodachi Dachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("dachi");
            HttpContext.Session.SetString("message", "Dachi slept");

            Dachi.Sleep();

            HttpContext.Session.SetObjectAsJson("dachi", Dachi);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("win")]

        public IActionResult Win() {

            HttpContext.Session.Clear();

            ViewBag.message = "Congrats, you won";
            
            return View("Win");
        }

        [HttpGet]
        [Route("loss")]

        public IActionResult Loss() {

            HttpContext.Session.Clear();

            ViewBag.message = "Dachi died";
            
            return View("Loss");
        }
    }
}
