using System.ComponentModel.DataAnnotations;

namespace Foody.Business.DAL.Entities.ClientMeasurements
{
    public class DailyIntakeLimitRecord
    {
        [Key]
        [Required]
        public int DailyIntakeLimitId { get; set; }

        [Required]
        public int UserId { get; set; }

        public double? DailyCaloriesIntake { get; set; }

        public double? DailyCarbsIntake { get; set; }

        public double? DailyProteinIntake { get; set; }

        public double? DailyFatIntake { get; set; }

        public double? DailyWaterIntake { get; set; }

        // Navigation property for the user associated with this goal
        public ClientUserRecord User { get; set; }
    }
}