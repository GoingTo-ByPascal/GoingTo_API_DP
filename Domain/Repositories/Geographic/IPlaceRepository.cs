
using GoingTo_API_DP.Domain.Model.Geographic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Repositories
{
    public interface IPlaceRepository
    {
        Task<IEnumerable<Place>> ListAsync();
        Task<IEnumerable<Place>> ListByCityIdAsync(int cityId);
        Task<Place> FindById(int id);
        Task AddAsync(Place place);
        void Update(Place place);
        void Remove(Place place);


    }
}
