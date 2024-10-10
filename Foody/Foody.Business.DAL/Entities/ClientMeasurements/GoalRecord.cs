using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.Business.DAL.Entities.ClientMeasurements
{
    public class GoalRecord
    {
        [Key]
        [Required]
        public int GoalId { get; set; }

        [Required]
        public int UserId { get; set; }

        public double? GoalWeightValue { get; set; }

        public double? CurrentWeightValue { get; set; }

        // Navigation property for the user associated with this goal
        public ClientUserRecord User { get; set; }
    }
}
