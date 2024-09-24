using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Models
{
    public class WaterIntake
    {
        [Key]
        [Required]
        public int WaterIntakeId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
    }
}
