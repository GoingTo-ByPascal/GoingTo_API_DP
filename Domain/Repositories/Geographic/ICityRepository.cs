using GoingTo_API_DP.Domain.Model.Geographic;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace GoingTo_API_DP.Domain.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> ListAsync();
        Task<IEnumerable<City>> ListByCountryIdAsync(int countryId);
        Task<City> FindById(int id);
    }
}
