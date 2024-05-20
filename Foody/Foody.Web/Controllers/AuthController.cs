using Foody.BLL.Interfaces.External;
using Foody.BLL.Interfaces.Internal;
using Foody.BLL.Services.Clients;
using Microsoft.AspNetCore.Mvc;

namespace Foody.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> IsRegistered([FromQuery] string chatId)
        {
            try
            {
                if (string.IsNullOrEmpty(chatId))
                {
                    //"No ID provided."
                    return new BadRequestResult();
                }
                    var result = await _userService.IsRegistered(chatId);
                    return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> RecognizeBarcode([FromBody] long upc)
        {
            try
            {
                
                return new OkResult();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
