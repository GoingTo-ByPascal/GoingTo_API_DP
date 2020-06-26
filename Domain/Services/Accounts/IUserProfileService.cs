
using System.Collections.Generic;
using System.Threading.Tasks;
using GoingTo_API_DP.Domain.Model.Accounts;
using GoingTo_API_DP.Domain.Services.Communications;

namespace GoingTo_API_DP.Domain.Services.Accounts
{
    public interface IUserProfileService
    {
        Task<IEnumerable<UserProfile>> ListAsync();
        Task<ProfileResponse> FindById(int userProfileId);
        Task<ProfileResponse> SaveAsync(UserProfile profile);
        Task<ProfileResponse> UpdateAsync(int id, UserProfile profile);
        Task<ProfileResponse> DeleteAsync(int id);
    }
}
