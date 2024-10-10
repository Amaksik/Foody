using Foody.IdentityAccessLayer.Record;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.IdentityAccessLayer.Records
{
    public class OrganizationUserRecord
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public ApplicationUserRecord User { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Website { get; set; }

        public ICollection<TrainerUserRecord> Trainers { get; set; }

    }
}
