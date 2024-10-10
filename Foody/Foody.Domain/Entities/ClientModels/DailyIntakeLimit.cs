using System.ComponentModel.DataAnnotations;

namespace Foody.Domain.Entities.ClientModels
{
    public class DailyIntakeLimit
    {
        [Key]
        [Required]
        public int DailyIntakeLimitId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public double DailyCaloriesIntake { get; set; }

        [Required]
        public double DailyCarbsIntake { get; set; }

        [Required]
        public double DailyProteinIntake { get; set; }

        [Required]
        public double DailyFatIntake { get; set; }

        [Required]
        public double DailyWaterIntake { get; set; }
    }
}