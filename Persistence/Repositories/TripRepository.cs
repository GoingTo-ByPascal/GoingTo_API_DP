using GoingTo_API_DP.Domain.Model;
using GoingTo_API_DP.Domain.Model.Accounts;
using GoingTo_API_DP.Domain.Persistence.Context;
using GoingTo_API_DP.Domain.Repositories.Geographic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Persistence.Repositories
{
    public class TripRepository : BaseRepository, ITripRepository
    {
        public TripRepository(AppDbContext context) : base(context){}

        public async Task AddAsync(Trip trip)
        {
            await _context.Trips.AddAsync(trip);
        }

        public async Task<Trip> FindById(int id)
        {
            return await _context.Trips.FindAsync(id);
        }

        public async Task<IEnumerable<Trip>> ListAsync()
        {
            return await _context.Trips.ToListAsync();
        }

        public async Task<IEnumerable<Trip>> ListByUserIdAsync(int userId)
        {
            return await _context.Trips
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        public  void Remove(Trip trip)
        {
            _context.Trips.Remove(trip);
        }

        public void Update(Trip trip)
        {
             _context.Trips.Update(trip);
        }
    }
}
