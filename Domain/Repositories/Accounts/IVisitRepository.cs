using GoingTo_API_DP.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Repositories.Geographic
{
    public interface IVisitRepository
    {
        Task<IEnumerable<Visit>> ListAsync();
        Task<IEnumerable<Visit>> ListByTripIdAsync(int tripId);
        Task<Visit> FindByTripIdAndLocatableId(int tripId, int locatableId);
        Task AssignVisit(int tripId, int locatableId);
        Task UnassignVisit(int tripId, int locatableId);
        Task AddAsync(Visit visit);
        Task<Visit> FindById(int id);
        void Update(Visit visit);
        void Remove(Visit visit);
    }
}
