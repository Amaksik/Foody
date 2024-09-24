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
                var exists = await _userService.IsRegistered(chatId);
                if (!exists)
                {
                    return NotFound();
                }
                return Ok(exists);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
