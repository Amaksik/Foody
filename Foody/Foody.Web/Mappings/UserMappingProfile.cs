using AutoMapper;
using Foody.BLL.Models;
using Foody.Web.Models.Requests;
using Foody.Web.Models.Requests.Client;

namespace Foody.Web.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, CreateUserReq>().ReverseMap();

            CreateMap<CreateWaterIntakeReq, WaterIntake>().ReverseMap();

            CreateMap<CreateFoodIntakeReq, FoodIntake>().ReverseMap();
        }
    }
}
