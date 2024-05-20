using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Foody.DAL.Entities
{
    public class FoodIntakeRecord
    {
        [Key]
        [Required]
        public int FoodIntakeId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public double Calories { get; set; }

        public double? Carbs { get; set; }

        public double? Fat { get; set; }

        public double? Protein { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        // Navigation property for the user who consumed this food intake
        public UserRecord User { get; set; }
    }
}
