using Foody.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Interfaces.DAL
{
    public interface IFoodIntakesRepository
    {
        Task<IEnumerable<FoodIntake>> GetFoodIntakesForUserAsync(int userId);
        Task<IEnumerable<FoodIntake>> GetFoodIntakesForUserInPeriodAsync(int userId, DateTime startDate, DateTime endDate);
        Task AddFoodIntakeAsync(int userId, FoodIntake foodIntake);
        Task UpdateFoodIntakeAsync(FoodIntake foodIntake);
        Task DeleteFoodIntakeAsync(int foodIntakeId);
    }
}
