using Foody.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.Domain.Interfaces
{
    public interface IApplicationUserRepository
    {
        Task<ApplicationUser> GetAsync(int id);

        Task UpdateAsync(ApplicationUser user);

        Task RemoveAsync(int id);
    }
}
