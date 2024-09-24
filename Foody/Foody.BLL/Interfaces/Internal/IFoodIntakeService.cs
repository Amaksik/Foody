using Foody.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Interfaces.Internal
{
    public interface IFoodIntakeService
    {
        Task AddFoodIntakeAsync(string chatId, FoodIntake foodIntake);

        Task DeleteFoodIntakeAsync(int foodIntakeId);

        Task<IEnumerable<FoodIntake>> GetFoodIntakesForUserAsync(string chatId);

        Task<IEnumerable<FoodIntake>> GetFoodIntakesForUserInPeriodAsync(string chatId, DateTime startDate, DateTime endDate);

    }
}
