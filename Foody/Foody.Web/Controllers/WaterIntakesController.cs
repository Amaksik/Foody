using Foody.BLL.Interfaces.Internal;
using Foody.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Foody.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WaterIntakesController : ControllerBase
    {
        private readonly IWaterIntakeService _waterIntakesService;

        public WaterIntakesController(IWaterIntakeService waterIntakesService)
        {
            _waterIntakesService = waterIntakesService;
        }

        [HttpGet("{chatId}")]
        public async Task<ActionResult<IEnumerable<WaterIntake>>> GetWaterIntakesForUser(string chatId)
        {
            try
            {
                var waterIntakes = await _waterIntakesService.GetWaterIntakesForUserAsync(chatId);
                return Ok(waterIntakes);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("User not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{chatId}/period")]
        public async Task<ActionResult<IEnumerable<WaterIntake>>> GetWaterIntakesForUserInPeriod(string chatId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var waterIntakes = await _waterIntakesService.GetWaterIntakesForUserInPeriodAsync(chatId, startDate, endDate);
                return Ok(waterIntakes);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("User not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPost("{chatId}")]
        public async Task<ActionResult> AddWaterIntake(string chatId, [FromBody] WaterIntake waterIntake)
        {
            try
            {
                await _waterIntakesService.AddWaterIntakeAsync(chatId, waterIntake);
                return Ok("Water intake added successfully.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("User not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{chatId}/{waterIntakeId}")]
        public async Task<ActionResult> DeleteWaterIntake(string chatId, int waterIntakeId)
        {
            try
            {
                await _waterIntakesService.DeleteWaterIntakeAsync(chatId, waterIntakeId);
                return Ok("Water intake deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
