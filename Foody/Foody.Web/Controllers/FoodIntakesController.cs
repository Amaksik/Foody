using AutoMapper;
using Foody.BLL.Interfaces.Internal;
using Foody.BLL.Models;
using Foody.Web.Models.Requests.Client;
using Microsoft.AspNetCore.Mvc;

namespace Foody.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodIntakesController : ControllerBase
    {
        private readonly IFoodIntakeService _foodIntakeService;
        private readonly IMapper _mapper;

        public FoodIntakesController(IFoodIntakeService foodIntakeService, IMapper mapper)
        {
            _foodIntakeService = foodIntakeService;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddFoodIntake(string chatId, [FromBody] CreateFoodIntakeReq foodIntake)
        {
            try
            {
                var intake = _mapper.Map<FoodIntake>(foodIntake);
                await _foodIntakeService.AddFoodIntakeAsync(chatId, intake);
                return Ok("Food intake added successfully.");
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

        [HttpDelete("delete/{foodIntakeId}")]
        public async Task<IActionResult> DeleteFoodIntake(int foodIntakeId)
        {
            try
            {
                await _foodIntakeService.DeleteFoodIntakeAsync(foodIntakeId);
                return Ok("Food intake deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetFoodIntakesForUser(string chatId)
        {
            try
            {
                var foodIntakes = await _foodIntakeService.GetFoodIntakesForUserAsync(chatId);
                return Ok(foodIntakes);
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

        [HttpGet("getPeriod")]
        public async Task<IActionResult> GetFoodIntakesForUserInPeriod(string chatId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var foodIntakes = await _foodIntakeService.GetFoodIntakesForUserInPeriodAsync(chatId, startDate, endDate);
                return Ok(foodIntakes);
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
