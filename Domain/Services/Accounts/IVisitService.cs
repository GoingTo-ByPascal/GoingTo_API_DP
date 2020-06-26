using GoingTo_API_DP.Domain.Model;
using GoingTo_API_DP.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Services.Accounts
{
    public interface IVisitService
    {
        Task<IEnumerable<Visit>> ListAsync();
        Task<VisitResponse> FindById(int id);
        Task<VisitResponse> SaveAsync(Visit visit);
        Task<VisitResponse> UpdateAsync(int id, Visit visit);
        Task<VisitResponse> DeleteAsync(int id);
        
    }
}
