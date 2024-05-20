using Foody.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Interfaces.Internal
{
    public interface IWaterIntakeService
    {
        Task AddWaterIntakeAsync(string chatId, WaterIntake waterIntake);
        Task DeleteWaterIntakeAsync(string chatId, int waterIntakeId);
        Task<IEnumerable<WaterIntake>> GetWaterIntakesForUserAsync(string chatId);
        Task<IEnumerable<WaterIntake>> GetWaterIntakesForUserInPeriodAsync(string chatId, DateTime startDate, DateTime endDate);

    }
}
