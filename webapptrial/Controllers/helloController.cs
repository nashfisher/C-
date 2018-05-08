using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace YourNamespace.Controllers
{
    public class HelloController : Controller
    {
        [HttpGet]
        [Route("")]
        public string Index()
        {
            return "Scuba time";
        }


        // Return a Json Object
        // [HttpGet]
        // [Route("")]
        // public JsonResult Example() {
        //     return Json(some_object);
        // }

        // Post Route
        // [HttpPost]
        // [Route("")]
        // public IActionResult Other() {
            
        // }

        // Route with route parameter
        // [HttpGet]
        // [Route("template/{Name}")]
        // public IActionResult Method(string Name) {
            
        // }
    }
}
