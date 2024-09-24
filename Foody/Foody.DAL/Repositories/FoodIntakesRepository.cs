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
    public class FoodIntakesRepository : IFoodIntakesRepository
    {
        private readonly FoodyDbContext _context;
        private IMapper _mapper;

        public FoodIntakesRepository(FoodyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddFoodIntakeAsync(int userId, FoodIntake foodIntake)
        {
            var user = _context.Users.First(u => u.UserId == userId);
            var record = _mapper.Map<FoodIntakeRecord>(foodIntake);
            record.DateTime = DateTime.UtcNow;

            user.FoodIntakes.Add(record);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteFoodIntakeAsync(int foodIntakeId)
        {
            var foodIntake = await _context.FoodIntakes.FindAsync(foodIntakeId);
            if (foodIntake != null)
            {
                _context.FoodIntakes.Remove(foodIntake);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<FoodIntake>> GetFoodIntakesForUserAsync(int userId)
        {
            var records = await _context.FoodIntakes
                                .Where(fi => fi.UserId == userId)
                                .ToListAsync();
            return _mapper.Map<IEnumerable<FoodIntake>>(records);
        }

        public async Task<IEnumerable<FoodIntake>> GetFoodIntakesForUserInPeriodAsync(int userId, DateTime startDate, DateTime endDate)
        {
            var records = await _context.FoodIntakes
                                .Where(fi => fi.UserId == userId && fi.DateTime >= startDate && fi.DateTime <= endDate)
                                .ToListAsync();
            return _mapper.Map<IEnumerable<FoodIntake>>(records);

        }

        public async Task UpdateFoodIntakeAsync(FoodIntake foodIntake)
        {
            var foodIntakerecord = await _context.FoodIntakes.FindAsync(foodIntake.FoodIntakeId);
            if (foodIntakerecord != null)
            {
                foodIntakerecord.Calories = foodIntake.Calories;
                foodIntakerecord.Protein = foodIntake.Protein;
                foodIntakerecord.Carbs = foodIntake.Carbs;
                foodIntakerecord.Fat = foodIntake.Fat;
                await _context.SaveChangesAsync();
            }
        }

        private IQueryable<UserRecord> FoodIntakes => _context.Users
            .Include(c => c.FoodIntakes)
            .Include(c => c.PersonalGoal);
    }
}
