using Foody.BLL.Interfaces.DAL;
using Foody.BLL.Interfaces.Internal;
using Foody.BLL.Models.ViewModels;
using Foody.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Services.Internal
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _usersRepository;
        public UserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<bool> IsRegistered(string chatId)
        {
            var user = await _usersRepository.GetUserByChatIdAsync(chatId);
            return user != null ? true : false;
        }

        public async Task<UserVM> GetAccountViewModel(string chatId)
        {
            var user = await _usersRepository.GetFullUserByChatIdAsync(chatId);
            if (user != null)
            {
                var vm = GetUserVM(user);

                return vm;
            }
            else
            {
                throw new KeyNotFoundException("User not found.");
            }
        }

        private UserVM GetUserVM(User user)
        {
            var vm = new UserVM();
            //basic information
            vm.Name = user.Name;
            vm.Surname = user.Surname;
            vm.Email = user.Email;
            vm.Phone = user.Phone;


            //daily progress
            var today = DateTime.UtcNow.Date;
            if (user.DailyLimits.DailyWaterIntake != 0)
            {
                var todayConsumed = user.WaterIntakes.Where(i => i.DateTime.Date == today).Sum(intake => intake.Amount);
                vm.DailyWaterPercentage = (int)(todayConsumed / user.DailyLimits.DailyWaterIntake * 100);

            }
            if (user.DailyLimits.DailyCaloriesIntake != 0)
            {
                var todayConsumedCalories = user.FoodIntakes.Where(i => i.DateTime.Date == today).Sum(intake => intake.Calories);
                var todayConsumedCarbs = user.FoodIntakes.Where(i => i.DateTime.Date == today).Sum(intake => intake.Carbs);
                var todayConsumedProtein = user.FoodIntakes.Where(i => i.DateTime.Date == today).Sum(intake => intake.Protein);
                var todayConsumedFat = user.FoodIntakes.Where(i => i.DateTime.Date == today).Sum(intake => intake.Fat);

                vm.DailyCaloriesPercentage = (int)(todayConsumedCalories / user.DailyLimits.DailyCaloriesIntake * 100);
                vm.DailyCarbsPercentage = (int)(todayConsumedCarbs / user.DailyLimits.DailyCarbsIntake * 100);
                vm.DailyProteinPercentage = (int)(todayConsumedProtein / user.DailyLimits.DailyProteinIntake * 100);
                vm.DailyFatPercentage = (int)(todayConsumedFat / user.DailyLimits.DailyFatIntake * 100);

            }

            //other information
            vm.PersonalGoal = user.PersonalGoal;
            vm.CurrentMeasurements = user.CurrentMeasurements;
            vm.DailyLimits = user.DailyLimits;

            //consumption information
            vm.FoodIntakes = user.FoodIntakes;
            vm.WaterIntakes = user.WaterIntakes;

            return vm;

        }


        public async Task AddUserAsync(User user)
        {
            var existed = _usersRepository.GetFullUserByChatIdAsync(user.ChatId);
            if (existed != null)
            {

                await _usersRepository.AddUserAsync(user);
            }
            else
            {
                throw new Exception("User already exists");
            }
        }

        public async Task DeleteUserAsync(string chatId)
        {
            var user = _usersRepository.GetUserByChatIdAsync(chatId);
            await _usersRepository.DeleteUserAsync(user.Id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _usersRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            try
            {
                return await _usersRepository.GetUserByIdAsync(userId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public async Task UpdateUserAsync(User user)
        {
            var existedUser = await _usersRepository.GetUserByChatIdAsync(user.ChatId);
            if (existedUser != null)
            {
                // Update userRecord properties with values from the user 
                existedUser.Name = user.Name;
                existedUser.Surname = user.Surname;
                existedUser.Email = user.Email;
                existedUser.Phone = user.Phone;

                // Save changes to the database
                await _usersRepository.UpdateUserAsync(user);
            }


        }

        public async Task UpdateUserDailyLimitsAsync(string chatId, DailyIntakeLimit dailyLimits)
        {
            var existedUser = await _usersRepository.GetUserByChatIdAsync(chatId);
            if (existedUser != null)
            {
                // Save changes to the database
                await _usersRepository.UpdateUserConfigurationAsync(chatId, dailyLimits);
            }
            else
            {
                throw new KeyNotFoundException("User not found.");
            }
        }

        public async Task UpdateUserPersonalGoalAsync(string chatId, Goal personalGoal)
        {
            var existedUser = await _usersRepository.GetUserByChatIdAsync(chatId);
            if (existedUser != null)
            {
                // Save changes to the database
                await _usersRepository.UpdateUserConfigurationAsync(chatId, personalGoal);
            }
            else
            {
                throw new KeyNotFoundException("User not found.");
            }
        }

        public async Task UpdateUserCurrentMeasurementsAsync(string chatId, Measurements currentMeasurements)
        {
            var existedUser = await _usersRepository.GetUserByChatIdAsync(chatId);
            if (existedUser != null)
            {
                // Save changes to the database
                await _usersRepository.UpdateUserConfigurationAsync(chatId, currentMeasurements);
            }
            else
            {
                throw new KeyNotFoundException("User not found.");
            }
        }

    }
}
