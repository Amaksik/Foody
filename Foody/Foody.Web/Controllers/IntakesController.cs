using Microsoft.AspNetCore.Mvc;

namespace Foody.Web.Controllers
{
    public class IntakesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
