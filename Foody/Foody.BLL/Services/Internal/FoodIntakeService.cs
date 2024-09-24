using Foody.BLL.Interfaces.DAL;
using Foody.BLL.Interfaces.Internal;
using Foody.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Services.Internal
{
    public class FoodIntakeService : IFoodIntakeService
    {
        private readonly IFoodIntakesRepository _foodIntakesRepository;
        private readonly IUsersRepository _usersRepository;

        public FoodIntakeService(IFoodIntakesRepository foodIntakesRepository, IUsersRepository usersRepository)
        {
            _foodIntakesRepository = foodIntakesRepository;
            _usersRepository = usersRepository;
        }

        public async Task AddFoodIntakeAsync(string chatId, FoodIntake foodIntake)
        {
            var user = await GetUserByChatIdAsync(chatId);
            if (user != null)
            {
                await _foodIntakesRepository.AddFoodIntakeAsync(user.UserId, foodIntake);
            }
            else
            {
                throw new KeyNotFoundException($"User with ChatId '{chatId}' not found.");
            }
        }

        public async Task DeleteFoodIntakeAsync(int foodIntakeId)
        {
            await _foodIntakesRepository.DeleteFoodIntakeAsync(foodIntakeId);
        }

        public async Task<IEnumerable<FoodIntake>> GetFoodIntakesForUserAsync(string chatId)
        {
            var user = await GetUserByChatIdAsync(chatId);
            if (user != null)
            {
                return await _foodIntakesRepository.GetFoodIntakesForUserAsync(user.UserId);
            }
            else
            {
                throw new KeyNotFoundException($"User with ChatId '{chatId}' not found.");
            }
        }

        public async Task<IEnumerable<FoodIntake>> GetFoodIntakesForUserInPeriodAsync(string chatId, DateTime startDate, DateTime endDate)
        {
            var user = await GetUserByChatIdAsync(chatId);
            if (user != null)
            {
                return await _foodIntakesRepository.GetFoodIntakesForUserInPeriodAsync(user.UserId, startDate, endDate);
            }
            else
            {
                throw new KeyNotFoundException($"User with ChatId '{chatId}' not found.");
            }
        }

        public async Task UpdateFoodIntakeAsync(FoodIntake foodIntake)
        {
            await _foodIntakesRepository.UpdateFoodIntakeAsync(foodIntake);
        }

        private async Task<User> GetUserByChatIdAsync(string chatId)
        {
            return await _usersRepository.GetUserByChatIdAsync(chatId);
        }
    }
}
