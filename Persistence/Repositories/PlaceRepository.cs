﻿
using GoingTo_API_DP.Domain.Model.Geographic;
using GoingTo_API_DP.Domain.Persistence.Context;
using GoingTo_API_DP.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Persistence.Repositories
{
    public class PlaceRepository : BaseRepository, IPlaceRepository
    {
        public PlaceRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Place place)
        {
            await _context.Places.AddAsync(place);
        }
        public async Task<Place> FindById(int id)
        {
            return await _context.Places
                .Where(p => p.Id == id)
                .Include(p => p.Locatable)
                .Include(p => p.City.Locatable)
                .Include(p => p.City.Country.Locatable)
                .FirstAsync();
        }

        public async Task<IEnumerable<Place>> ListAsync()
        {
            return await _context.Places
                .Include(p=>p.Locatable)
                .Include(p=>p.City)
                .Include(p=>p.City.Locatable)
                .ToListAsync();
        }

      

        public void Remove(Place place)
        {
            _context.Places.Remove(place);
        }

        public void Update(Place place)
        {
            _context.Places.Update(place);
        }

        public async Task<IEnumerable<Place>> ListByCityIdAsync(int cityId) =>
            await _context.Places
                .Where(p => p.CityId == cityId)
                .Include(p=>p.Locatable)
                .Include(p => p.City)
                .ToListAsync();
    }
}
