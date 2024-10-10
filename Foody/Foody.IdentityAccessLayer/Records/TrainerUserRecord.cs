using Foody.DAL.Entities;
using Foody.Domain.Entities;
using Foody.IdentityAccessLayer.Record;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.IdentityAccessLayer.Records
{
    public class TrainerUserRecord
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public ApplicationUserRecord User { get; set; }

        [ProtectedPersonalData]
        public string FirstName { get; set; }

        [ProtectedPersonalData]
        public string LastName { get; set; }

        public string SocialMediaProfileUrl { get; set; }

        [ProtectedPersonalData]
        public DateTime DateOfBirth { get; set; }

        [ProtectedPersonalData]
        public Gender Gender { get; set; }

        public int? OrganizationId { get; set; }

        public OrganizationUserRecord Organization { get; set; }

        public ICollection<ClientUserRecord> Clients { get; set; }

        //public ICollection<SingleTrainingRecord> Trainings { get; set; }

    }
}
