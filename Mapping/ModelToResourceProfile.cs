
using GoingTo_API_DP.Domain.Model.Accounts;
using GoingTo_API_DP.Domain.Model.Business;
using GoingTo_API_DP.Domain.Model.Geographic;
using GoingTo_API_DP.Resources;

namespace GoingTo_API_DP.Mapping
{
    public class ModelToResourceProfile : AutoMapper.Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Locatable, LocatableResource>();
            CreateMap<User, UserResource>();
            CreateMap<Country, CountryResource>();
            CreateMap<City, CityResource>();
            CreateMap<Place, PlaceResource>();
            CreateMap<Plan, PlanResource>();
            CreateMap<PlanUser, UserPlanResource>();
            CreateMap<UserProfile, UserProfileResource>();
        }
    }
}
