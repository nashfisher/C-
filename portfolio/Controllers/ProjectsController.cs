using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace portfolio.Controllers
{
    public class ProjectsController : Controller
    {
        [HttpGet]
        [Route("/projects")]
        public IActionResult Projects()
        {
            return View("Index");
        }
    }
}