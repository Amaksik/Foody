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
    public class WaterIntakesRepository : IWaterIntakesRepository
    {
        private readonly FoodyDbContext _context;
        private readonly IMapper _mapper;

        public WaterIntakesRepository(FoodyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WaterIntake>> GetWaterIntakesForUserAsync(int userId)
        {
            var records = await _context.WaterIntakes
                            .Where(wi => wi.UserId == userId)
                            .ToListAsync();
            return _mapper.Map<IEnumerable<WaterIntake>>(records);
        }

        public async Task<IEnumerable<WaterIntake>> GetWaterIntakesForUserInPeriodAsync(int userId, DateTime startDate, DateTime endDate)
        {
            var records = await _context.WaterIntakes
                            .Where(wi => wi.UserId == userId && wi.DateTime >= startDate && wi.DateTime <= endDate)
                            .ToListAsync();
            return _mapper.Map<IEnumerable<WaterIntake>>(records);
        }

        public async Task AddWaterIntakeAsync(int userId, WaterIntake waterIntake)
        {
            var user = _context.Users.First(u => u.UserId == userId);
            var record = _mapper.Map<WaterIntakeRecord>(waterIntake);
            record.DateTime = DateTime.UtcNow;

            user.WaterIntakes.Add(record);
            _context.WaterIntakes.Add(record);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteWaterIntakeAsync(int waterIntakeId)
        {
            var waterIntake = await _context.WaterIntakes.FindAsync(waterIntakeId);
            if (waterIntake != null)
            {
                _context.WaterIntakes.Remove(waterIntake);
                await _context.SaveChangesAsync();
            }
        }
    }
}
