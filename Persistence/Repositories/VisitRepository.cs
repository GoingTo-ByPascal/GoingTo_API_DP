using GoingTo_API_DP.Domain.Model;
using GoingTo_API_DP.Domain.Persistence.Context;
using GoingTo_API_DP.Domain.Repositories.Geographic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Persistence.Repositories
{
    public class VisitRepository : BaseRepository, IVisitRepository
    {
        public VisitRepository(AppDbContext context) : base(context){}

        public async Task AddAsync(Visit visit)
        {
            await _context.Visits.AddAsync(visit);
        }

        public async Task<Visit> FindById(int id)
        {
            return await _context.Visits.FindAsync(id);
        }

        public async Task<IEnumerable<Visit>> ListAsync()
        {
            return await _context.Visits.ToListAsync();
        }

        public async Task<IEnumerable<Visit>> ListByTripIdAsync(int tripId)
        {
            return await _context.Visits
                .Where(p => p.TripId == tripId)
                .ToListAsync();
        }

        public void Remove(Visit visit)
        {
            _context.Visits.Remove(visit);
        }

        public void Update(Visit visit)
        {
            _context.Visits.Update(visit);
        }
    }
}
