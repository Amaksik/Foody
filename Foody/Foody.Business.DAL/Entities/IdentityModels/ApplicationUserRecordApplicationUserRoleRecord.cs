using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.Business.DAL.Entities.IdentityModels
{
    public class ApplicationUserRecordApplicationUserRoleRecord : IdentityUserRole<int>
    {
        public virtual int UserId { get; set; }
        public virtual int RoleId { get; set; }

        public virtual ApplicationUserRoleRecord Role { get; set; }
    }
}
