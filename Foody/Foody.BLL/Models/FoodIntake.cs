using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Models
{
    public class FoodIntake
    {
        [Key]
        [Required]
        public int FoodIntakeId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int Calories { get; set; }

        public int? Carbs { get; set; }

        public int? Fat { get; set; }

        public int? Protein { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
    }
}
