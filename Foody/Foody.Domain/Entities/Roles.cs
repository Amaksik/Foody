using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.Domain.Entities
{
    public enum Roles
    {
        Client = 1,
        Trainer = 2,
        Organization = 3,
        SuperAdmin = 4
    }
}
