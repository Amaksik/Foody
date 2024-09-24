using Foody.BLL.Models;
using Foody.BLL.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Interfaces.Internal
{
    public interface IUserService
    {
        Task<bool> IsRegistered(string chatId);

        Task<UserVM> GetAccountViewModel(string chatId);

        Task AddUserAsync(User user);

        Task DeleteUserAsync(string userId);

        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<User> GetUserByIdAsync(int userId);

        Task UpdateUserAsync(User user);

        Task UpdateUserDailyLimitsAsync(string chatId, DailyIntakeLimit dailyLimits);

        Task UpdateUserPersonalGoalAsync(string chatId, Goal personalGoal);

        Task UpdateUserCurrentMeasurementsAsync(string chatId, Measurements currentMeasurements);

    }
}
