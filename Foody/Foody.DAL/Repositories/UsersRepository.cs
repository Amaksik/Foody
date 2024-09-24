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

            userRecord.WaterIntakes = new List<WaterIntakeRecord>();
            userRecord.FoodIntakes = new List<FoodIntakeRecord>();
            userRecord.CurrentMeasurements = new MeasurementsRecord();
            userRecord.PersonalGoal = new GoalRecord();
            userRecord.DailyLimits = new DailyIntakeLimitRecord();

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
                .SingleAsync(u => u.UserId == userId);

            return _mapper.Map<User>(userRecord);
        }

        public async Task<User> GetUserByChatIdAsync(string chatId)
        {
            var userRecord = await _context.Users
                .Include(u => u.WaterIntakes)
                .Include(u => u.FoodIntakes)
                .Include(u => u.PersonalGoal)
                .FirstOrDefaultAsync(u => u.ChatId == chatId);

            return _mapper.Map<User>(userRecord);
        }
        public async Task<User> GetFullUserByChatIdAsync(string chatId)
        {
            var userRecord = await _context.Users
                .Include(u => u.PersonalGoal)
                .Include(u => u.CurrentMeasurements)
                .Include(u => u.DailyLimits)
                .Include(u => u.WaterIntakes)
                .Include(u => u.FoodIntakes)
                .FirstOrDefaultAsync(u => u.ChatId == chatId);

            return _mapper.Map<User>(userRecord);
        }


        public async Task UpdateUserAsync(User user)
        {
            var userRecord = await _context.Users.Where(u => u.ChatId == user.ChatId).FirstOrDefaultAsync();
            if (userRecord != null)
            {
                // Update userRecord properties with values from the user object
                userRecord = _mapper.Map<UserRecord>(user);

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateUserConfigurationAsync<T>(string chatId, T config) where T : class
        {
            var userRecord = await _context.Users
                .Include(u => u.CurrentMeasurements)
                .Include(u => u.DailyLimits)
                .Include(u => u.PersonalGoal)
                .FirstOrDefaultAsync(u => u.ChatId == chatId);

            if (userRecord != null)
            {
                if (config is DailyIntakeLimit dailyLimit)
                {
                    userRecord.DailyLimits = _mapper.Map<DailyIntakeLimitRecord>(dailyLimit);
                }
                else if (config is Goal goal)
                {
                    userRecord.PersonalGoal = _mapper.Map<GoalRecord>(goal);
                }
                else if (config is Measurements measurements)
                {
                    userRecord.CurrentMeasurements = _mapper.Map<MeasurementsRecord>(measurements);
                }
                else
                {
                    throw new KeyNotFoundException($"User property of type {typeof(T)} not found.");
                }

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("User not found.");
            }
        }
    }
}
