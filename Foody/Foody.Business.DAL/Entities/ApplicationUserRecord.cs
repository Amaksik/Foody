using Foody.Business.DAL.Entities.IdentityModels;
using Foody.Domain.Entities;

namespace Foody.Business.DAL.Entities
{
    public class ApplicationUserRecord 
    {
        public virtual ICollection<ApplicationUserRecordApplicationUserRoleRecord> Roles { get; set; }
        
    }
}