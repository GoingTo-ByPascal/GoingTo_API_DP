using GoingTo_API_DP.Domain.Model.Geographic;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace GoingTo_API_DP.Domain.Repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> ListAsync();
        Task<Country> FindById(int id);
        Task<Country> FindByFullName(string fullname);
        Task<Country> ListByLocatableIdAsync(int locatableId);
    }
}
