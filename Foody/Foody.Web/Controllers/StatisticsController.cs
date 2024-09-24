using Microsoft.AspNetCore.Mvc;

namespace Foody.Web.Controllers
{
    public class StatisticsController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
