using Foody.Domain.Entities.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.Domain.Entities
{
    public class Client : ApplicationUser
    {

        public string ChatId { get; set; }

        public DailyIntakeLimit DailyLimits { get; set; }

        public Goal PersonalGoal { get; set; }

        public Measurements CurrentMeasurements { get; set; }

        public ICollection<FoodIntake> FoodIntakes { get; set; }

        public ICollection<WaterIntake> WaterIntakes { get; set; }
        // Relationship with DailyIntakeLimit
        public virtual ICollection<DailyIntakeLimit> DailyIntakeLimits { get; set; }
    }
}
