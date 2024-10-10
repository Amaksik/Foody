using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.Business.DAL.Entities.ClientMeasurements
{
    public class MeasurementsRecord
    {
        [Key]
        [Required]
        public int MeasurementsId { get; set; }

        [Required]
        public int UserId { get; set; }

        public double? Height { get; set; }

        public double? Weight { get; set; }

        // Navigation property for the user associated with this goal
        public ClientUserRecord User { get; set; }
    }
}
