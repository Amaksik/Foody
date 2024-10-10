using AutoMapper;
using Foody.Domain.Entities;
using Foody.Domain.Interfaces;
using Foody.IdentityAccessLayer.Record;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.IdentityAccessLayer.Repositories
{
    internal class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly IMapper _mapper;
        private readonly FoodyIdentityContext _foodyIdentityContext;

        public ApplicationUserRepository(IMapper mapper, FoodyIdentityContext foodyIdentityContext)
        {
            _mapper = mapper;
            _foodyIdentityContext = foodyIdentityContext;
        }

        public async Task<ApplicationUser> GetAsync(int userId)
        {
            var storedUser = await Users.SingleOrDefaultAsync(u => u.Id == userId);

            return _mapper.Map<ApplicationUser>(storedUser);
        }

        public async Task UpdateAsync(ApplicationUser user)
        {
            var storedUser = await Users.SingleAsync(u => u.Id == user.Id);

            _mapper.Map(user, storedUser);
        }

        public async Task RemoveAsync(int userId)
        {
            var storedUser = await _foodyIdentityContext.Users.SingleAsync(u => u.Id == userId);
            _foodyIdentityContext.Users.Remove(storedUser);
        }

        private IQueryable<ApplicationUserRecord> Users =>
            _foodyIdentityContext.Users
                .Include(x => x.Roles);
    }
}
