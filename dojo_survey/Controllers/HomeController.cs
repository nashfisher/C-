using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace dojo_survey.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("method")]
        public IActionResult Method(string name, string location, string language, string comment) {
            
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.comment = comment;

            return View("Result");
        }
    }
}
