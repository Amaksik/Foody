using Foody.Domain.Entities;
using Foody.IdentityAccessLayer.Records;
using Microsoft.AspNetCore.Identity;

namespace Foody.IdentityAccessLayer.Record
{
    public class ApplicationUserRecord : IdentityUser<int>
    {
        public virtual ICollection<ApplicationUserRecordApplicationUserRoleRecord> Roles { get; set; }
        public bool IsEnabled => !LockoutEnabled || !LockoutEnd.HasValue || LockoutEnd < DateTimeOffset.UtcNow;

        public DateTime CreationDate { get; set; }
        public DateTime? LastLoginDate { get; set; }

        [ProtectedPersonalData]
        public string FullName { get; set; }

        public ClientUserRecord? Client { get; set; }
        public TrainerUserRecord? Trainer { get; set; }
        public OrganizationUserRecord? Organization { get; set; }
    }
}