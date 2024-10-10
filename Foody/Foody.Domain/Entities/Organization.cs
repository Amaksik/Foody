using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.Domain.Entities
{
    public class Organization : ApplicationUser
    {
        // An organization manages multiple trainers
        public virtual ICollection<Trainer> Trainers { get; set; }
    }
}
