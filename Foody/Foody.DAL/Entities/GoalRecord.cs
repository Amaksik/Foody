using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.DAL.Entities
{
    public class GoalRecord
    {
        [Key]
        [Required]
        public int GoalId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public double GoalWeightValue { get; set; }

        [Required]
        public double CurrentWeightValue { get; set; }

        // Navigation property for the user associated with this goal
        public UserRecord User { get; set; }
    }
}
