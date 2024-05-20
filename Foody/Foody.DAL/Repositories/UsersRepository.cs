using AutoMapper;
using Foody.BLL.Interfaces.DAL;
using Foody.BLL.Models;
using Foody.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.DAL.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly FoodyDbContext _context;
        private readonly IMapper _mapper;

        public UsersRepository(FoodyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddUserAsync(User user)
        {
            var userRecord = _mapper.Map<UserRecord>(user);
            _context.Users.Add(userRecord);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            var userRecord = await _context.Users.FindAsync(userId);

            if (userRecord != null)
            {
                _context.Users.Remove(userRecord);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var userRecords = await _context.Users.ToListAsync();
            return _mapper.Map<IEnumerable<User>>(userRecords);
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            var userRecord = await _context.Users
                .Include(u => u.WaterIntakes)
                .Include(u => u.FoodIntakes)
                .Include(u => u.PersonalGoal)
                .SingleAsync( u=> u.UserId == userId);

            return _mapper.Map<User>(userRecord);
        }

        public async Task<User> GetUserByChatIdAsync(string chatId)
        {
            var userRecord = await _context.Users
                .Include(u => u.WaterIntakes)
                .Include(u => u.FoodIntakes)
                .Include(u => u.PersonalGoal)
                .SingleAsync(u => u.ChatId == chatId);

            return _mapper.Map<User>(userRecord);
        }

        public async Task UpdateUserAsync(User user)
        {
            var userRecord = await _context.Users.FindAsync(user.UserId);
            if (userRecord != null)
            {
                // Update userRecord properties with values from the user object
                userRecord.Name = user.Name;
                userRecord.Surname = user.Surname;
                userRecord.Email = user.Email;
                userRecord.Phone = user.Phone;

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
        }
    }
}
