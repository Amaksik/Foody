using Foody.Business.DAL.Entities.IdentityModels;
using Foody.Domain.Entities;

namespace Foody.Business.DAL.Entities
{
    public class ApplicationUserRecord 
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public virtual ICollection<ApplicationUserRecordApplicationUserRoleRecord> Roles { get; set; }
        
    }
}