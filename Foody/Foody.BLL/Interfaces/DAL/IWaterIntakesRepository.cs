using Foody.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Interfaces.DAL
{
    public interface IWaterIntakesRepository
    {
        Task<IEnumerable<WaterIntake>> GetWaterIntakesForUserAsync(int userId);
        Task<IEnumerable<WaterIntake>> GetWaterIntakesForUserInPeriodAsync(int userId, DateTime startDate, DateTime endDate);
        Task AddWaterIntakeAsync(int userId, WaterIntake waterIntake);
        Task DeleteWaterIntakeAsync(int waterIntakeId);
    }
}
