using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace callingcard.Controllers
{
    public class HelloController : Controller
    {

        [HttpGet]
        [Route("")]
        public string Index() {
            return "try the following address outline - localhost:5000/index/(first name here)/(last name here)/(age here)/(color here)";
        }

        [HttpGet]
        [Route("index/{first_name}/{last_name}/{age}/{color}")]
        public JsonResult DisplayPerson(string first_name, string last_name, int age, string color) {
            
            var AnonObject = new {
                FirstName = first_name,
                LastName = last_name,
                Age = age,
                FavoriteColor = color,
            };
            return Json(AnonObject);
        }
    }
}
