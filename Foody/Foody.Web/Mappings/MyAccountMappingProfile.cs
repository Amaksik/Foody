using AutoMapper;
using Foody.BLL.Models;
using Foody.Web.Models.Requests;

namespace Foody.Web.Mappings
{
    public class MyAccountMappingProfile : Profile
    {
        public MyAccountMappingProfile()
        {
            CreateMap<GoalReq, Goal>();

            CreateMap<MeasurementsReq, Measurements>();

            CreateMap<DailyIntakeLimitReq, DailyIntakeLimit>();
        }
    }
}
