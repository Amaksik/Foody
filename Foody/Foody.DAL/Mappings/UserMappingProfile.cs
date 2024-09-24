using AutoMapper;
using Foody.BLL.Models;
using Foody.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.DAL.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserRecord>()
                .ForMember(u => u.WaterIntakes, opt => opt.Ignore())
                .ForMember(x => x.FoodIntakes, opt => opt.Ignore())
                .ForMember(x => x.PersonalGoal, opt => opt.Ignore())
                .ForMember(x => x.CurrentMeasurements, opt => opt.Ignore())
                .ForMember(x => x.DailyLimits, opt => opt.Ignore());

            CreateMap<UserRecord, User>();

            CreateMap<DailyIntakeLimit, DailyIntakeLimitRecord>()
                .ForMember(x => x.UserId, opt => opt.Ignore())
                .ForMember(x => x.User, opt => opt.Ignore());

            CreateMap<DailyIntakeLimitRecord, DailyIntakeLimit>();

            CreateMap<Goal, GoalRecord>()
                .ForMember(x => x.UserId, opt => opt.Ignore())
                .ForMember(x => x.User, opt => opt.Ignore());

            CreateMap<GoalRecord, Goal>();

            CreateMap<Measurements, MeasurementsRecord>()
                .ForMember(x => x.UserId, opt => opt.Ignore())
                .ForMember(x => x.User, opt => opt.Ignore());

            CreateMap<MeasurementsRecord, Measurements>();

            CreateMap<FoodIntake, FoodIntakeRecord>().ReverseMap();

            CreateMap<WaterIntake, WaterIntakeRecord>().ReverseMap();
        }
    }
}
