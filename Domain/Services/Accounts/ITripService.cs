using GoingTo_API_DP.Domain.Model;
using GoingTo_API_DP.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Services.Accounts
{
    public interface ITripService
    {
        Task<IEnumerable<Trip>> ListAsync();
        Task<TripResponse> FindById(int id);
        Task<TripResponse> SaveAsync(Trip trip);
        Task<TripResponse> UpdateAsync(int id, Trip trip);
        Task<TripResponse> DeleteAsync(int id);
        Task<IEnumerable<Trip>> ListByUserIdAsync(int userId);
    }
}
