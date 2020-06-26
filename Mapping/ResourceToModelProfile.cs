
using GoingTo_API_DP.Domain.Model.Accounts;
using GoingTo_API_DP.Domain.Model.Business;
using GoingTo_API_DP.Domain.Model.Geographic;
using GoingTo_API_DP.Resources;
using GoingTo_API_DP.Resources.SaveResources;

namespace GoingTo_API_DP.Mapping
{
    public class ResourceToModelProfile : AutoMapper.Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveProfileResource, UserProfile>();
            CreateMap<SavePlaceResource, Place>();
            CreateMap<SavePlanResource, Plan>();
        }
    }
}

