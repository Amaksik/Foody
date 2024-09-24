using AutoMapper;
using Foody.BLL.Interfaces.Internal;
using Foody.BLL.Models;
using Foody.Web.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Foody.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] CreateUserReq userReq)
        {
            if (userReq == null)
            {
                return BadRequest("User is null");
            }

            var isRegistered = await _userService.IsRegistered(userReq.ChatId);
            if (isRegistered)
            {
                return Conflict("User already exists");
            }

            var user = _mapper.Map<User>(userReq);

            await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        }

        [HttpPut("{chatId}")]
        public async Task<IActionResult> UpdateUser(string chatId, [FromBody] CreateUserReq userReq)
        {
            if (userReq == null || string.IsNullOrEmpty(chatId))
            {
                return BadRequest("No User ID provided");
            }

            var existingUser = await _userService.IsRegistered(chatId);
            if (!existingUser)
            {
                return NotFound("User not found");
            }

            var user = _mapper.Map<User>(userReq);

            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{chatId}")]
        public async Task<IActionResult> DeleteUser(string chatId)
        {
            var existingUser = await _userService.IsRegistered(chatId);
            if (!existingUser)
            {
                return NotFound("User not found");
            }

            await _userService.DeleteUserAsync(chatId);
            return NoContent();
        }
    }
}
