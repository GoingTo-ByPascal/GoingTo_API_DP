
using GoingTo_API_DP.Domain.Model.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Repositories.Accounts
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task AddAsync(User user);
        Task<User> FindById(int id);
        void Update(User user);
        void Remove(User user);
    }
}
