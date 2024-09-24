using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Models.ViewModels
{
    public class UserVM
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int? DailyWaterPercentage { get; set; }

        public int? DailyCaloriesPercentage { get; set; }
        public int? DailyCarbsPercentage { get; set; }
        public int? DailyProteinPercentage { get; set; }
        public int? DailyFatPercentage { get; set; }

        public DailyIntakeLimit? DailyLimits { get; set; }

        // Navigation property for goal records
        public Goal? PersonalGoal { get; set; }

        // Navigation property for measurements records
        public Measurements? CurrentMeasurements { get; set; }

        // Navigation property for food intake records
        public ICollection<FoodIntake> FoodIntakes { get; set; }

        // Navigation property for water intake records
        public ICollection<WaterIntake> WaterIntakes { get; set; }
    }
}
