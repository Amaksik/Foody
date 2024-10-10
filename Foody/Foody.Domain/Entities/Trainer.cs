using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.Domain.Entities
{
    public class Trainer : ApplicationUser
    {
        // A trainer manages multiple clients
        public virtual ICollection<Client> Clients { get; set; }
    }
}
