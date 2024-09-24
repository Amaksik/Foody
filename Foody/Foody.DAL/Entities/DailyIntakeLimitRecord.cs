using System.ComponentModel.DataAnnotations;

namespace Foody.DAL.Entities
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
        public UserRecord User { get; set; }
    }
}