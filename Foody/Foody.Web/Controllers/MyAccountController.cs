using AutoMapper;
using Foody.BLL.Interfaces.Internal;
using Foody.BLL.Models;
using Foody.Web.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Foody.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyAccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public MyAccountController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("{chatId}")]
        public async Task<IActionResult> GetMyAccountVM(string chatId)
        {
            try
            {
                var vm = await _userService.GetAccountViewModel(chatId);
                return Ok(JsonSerializer.Serialize(vm));
            }
            catch (KeyNotFoundException)
            {
                return NotFound("User not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("updateDailyLimits")]
        public async Task<IActionResult> UpdateDailyLimits(string chatId, [FromBody] DailyIntakeLimitReq request)
        {
            try
            {
                var dailyLimits = _mapper.Map<DailyIntakeLimit>(request);
                await _userService.UpdateUserDailyLimitsAsync(chatId, dailyLimits);
                return Ok("Daily limits updated successfully.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("User not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("updatePersonalGoal")]
        public async Task<IActionResult> UpdatePersonalGoal(string chatId, [FromBody] GoalReq request)
        {
            try
            {
                var personalGoal = _mapper.Map<Goal>(request);
                await _userService.UpdateUserPersonalGoalAsync(chatId, personalGoal);
                return Ok("Personal goal updated successfully.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("User not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("updateCurrentMeasurements")]
        public async Task<IActionResult> UpdateCurrentMeasurements(string chatId, [FromBody] MeasurementsReq request)
        {
            try
            {
                var currentMeasurements = _mapper.Map<Measurements>(request);
                await _userService.UpdateUserCurrentMeasurementsAsync(chatId, currentMeasurements);
                return Ok("Current measurements updated successfully.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("User not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
