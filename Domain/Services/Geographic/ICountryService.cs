using GoingTo_API_DP.Domain.Model.Geographic;
using GoingTo_API_DP.Domain.Services.Communications;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace GoingTo_API_DP.Domain.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> ListAsync();
        Task<CountryResponse> GetByFullNameAsync(string fullname);
        Task<CountryResponse> GetByIdAsync(int id);
    }
}
