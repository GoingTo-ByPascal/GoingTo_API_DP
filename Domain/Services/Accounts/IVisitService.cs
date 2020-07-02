using GoingTo_API_DP.Domain.Model;
using GoingTo_API_DP.Domain.Services.Communications;
using GoingTo_API_DP.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Services.Accounts
{
    public interface IVisitService
    {
        Task<IEnumerable<Visit>> ListAsync();
        Task<VisitResponse> AssignVisitAsync(int tripId, int locatableId);
        Task<VisitResponse> UnassignVisitAsync(int tripId, int locatableId);
        Task<IEnumerable<Visit>> ListByTripIdAsync(int tripId);
        Task<VisitResponse> GetVisitState(int id);
        Task<VisitResponse> VisitPastState(int id);
        Task<VisitResponse> VisitFutureState(int id);
        Task<VisitResponse> VisitNeutralState(int id);
        Task<VisitResponse> FindByVisitId(int id);
    }
}
