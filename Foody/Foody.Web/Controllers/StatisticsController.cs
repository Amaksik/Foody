using Microsoft.AspNetCore.Mvc;

namespace Foody.Web.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
