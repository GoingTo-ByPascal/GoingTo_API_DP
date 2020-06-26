
using GoingTo_API_DP.Domain.Model.Accounts;
using GoingTo_API_DP.Domain.Services.Communications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Services.Accounts
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<UserResponse> SaveAsync(User user);
        Task<UserResponse> UpdateAsync(int id, User user);
        Task<UserResponse> DeleteAsync(int id);
        Task<UserResponse> GetByIdAsync(int id);

        
    }
}
