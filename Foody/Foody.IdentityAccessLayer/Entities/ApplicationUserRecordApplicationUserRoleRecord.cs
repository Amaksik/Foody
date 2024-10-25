using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.IdentityAccessLayer.Records
{
    public class ApplicationUserRecordApplicationUserRoleRecord : IdentityUserRole<int>
    {
        public virtual ApplicationUserRoleRecord Role { get; set; }
    }
}
