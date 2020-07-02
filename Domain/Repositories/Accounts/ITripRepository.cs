using GoingTo_API_DP.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Repositories.Geographic
{
    public interface ITripRepository
    {
        Task<IEnumerable<Trip>> ListAsync();
        Task<IEnumerable<Trip>> ListByUserIdAsync(int userId);
        Task AddAsync(Trip trip);
        Task<Trip> FindById(int id);
        void Update(Trip trip);
        void Remove(Trip trip);
    }
}
