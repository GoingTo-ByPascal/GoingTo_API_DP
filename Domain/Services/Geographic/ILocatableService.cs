
using GoingTo_API_DP.Domain.Model.Geographic;
using GoingTo_API_DP.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Services
{
    public interface ILocatableService
    {
        Task<IEnumerable<Locatable>> ListAsync();
        Task<LocatableResponse> SaveAsync(Locatable locatable);
        Task<LocatableResponse> UpdateAsync(int id, Locatable locatable);
        Task<LocatableResponse> DeleteAsync(int id); 
        Task<LocatableResponse> GetByIdAsync(int id);

    }
}
