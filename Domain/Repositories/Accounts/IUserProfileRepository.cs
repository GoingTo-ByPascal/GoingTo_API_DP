
using GoingTo_API_DP.Domain.Model.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Repositories.Accounts
{
    public interface IUserProfileRepository
    {
        Task<IEnumerable<UserProfile>> ListAsync(); 

        Task AddAsync(UserProfile profile); 

        Task<UserProfile> FindById(int id);
        void Update(UserProfile profile);

        void Remove(UserProfile profile); 
    }
}
