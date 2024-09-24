using System;
using Foody.BLL.Interfaces.DAL;
using Foody.BLL.Interfaces.Internal;
using Foody.BLL.Models;

namespace Foody.BLL.Services.Internal
{
    public class WaterIntakeService : IWaterIntakeService
    {
        private readonly IWaterIntakesRepository _waterIntakesRepository;
        private readonly IUsersRepository _userRepository;

        public WaterIntakeService(IWaterIntakesRepository waterIntakesRepository, IUsersRepository userRepository)
        {
            _waterIntakesRepository = waterIntakesRepository;
            _userRepository = userRepository;
        }

        public async Task AddWaterIntakeAsync(string chatId, WaterIntake waterIntake)
        {
            var user = await _userRepository.GetUserByChatIdAsync(chatId);
            if (user != null)
            {
                await _waterIntakesRepository.AddWaterIntakeAsync(user.UserId, waterIntake);
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public async Task DeleteWaterIntakeAsync(string chatId, int waterIntakeId)
        {
            var user = await _userRepository.GetUserByChatIdAsync(chatId);
            if (user != null)
            {
                var waterIntakes = await _waterIntakesRepository.GetWaterIntakesForUserAsync(user.UserId);
                var waterIntake = waterIntakes.FirstOrDefault(wi => wi.WaterIntakeId == waterIntakeId);
                if (waterIntake != null)
                {
                    await _waterIntakesRepository.DeleteWaterIntakeAsync(waterIntakeId);
                }
                else
                {
                    throw new Exception("Water intake not found");
                }
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public async Task<IEnumerable<WaterIntake>> GetWaterIntakesForUserAsync(string chatId)
        {
            var user = await _userRepository.GetUserByChatIdAsync(chatId);
            if (user != null)
            {
                return await _waterIntakesRepository.GetWaterIntakesForUserAsync(user.UserId);
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public async Task<IEnumerable<WaterIntake>> GetWaterIntakesForUserInPeriodAsync(string chatId, DateTime startDate, DateTime endDate)
        {
            var user = await _userRepository.GetUserByChatIdAsync(chatId);
            if (user != null)
            {
                return await _waterIntakesRepository.GetWaterIntakesForUserInPeriodAsync(user.UserId, startDate, endDate);
            }
            else
            {
                throw new Exception("User not found");
            }
        }
    }

}
