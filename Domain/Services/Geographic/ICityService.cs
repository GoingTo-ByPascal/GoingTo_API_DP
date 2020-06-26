using GoingTo_API_DP.Domain.Model.Geographic;
using GoingTo_API_DP.Domain.Services.Communications;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace GoingTo_API_DP.Domain.Services
{
    public interface ICityService
    {
        Task<IEnumerable<City>> ListAsync();
        Task<IEnumerable<City>> ListByCountryIdAsync(int countryId);
        Task<CityResponse> GetByIdAsync(int id);

    }
}
