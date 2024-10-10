using System.ComponentModel.DataAnnotations;

namespace Foody.Web.Models.Requests.Client
{
    public class DailyIntakeLimitReq
    {
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
