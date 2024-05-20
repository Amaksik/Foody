using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Models
{
    public class MeasurementsRecord
    {
        [Key]
        [Required]
        public int MeasurementsId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public double Height { get; set; }

        [Required]
        public double Weight { get; set; }
    }
}
