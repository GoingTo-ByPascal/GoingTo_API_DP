﻿
using GoingTo_API_DP.Domain.Model.Geographic;
using GoingTo_API_DP.Domain.Persistence.Context;
using GoingTo_API_DP.Domain.Repositories;
using GoingTo_API_DP.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Persistence.Repositories
{
    public class CountryRepository : BaseRepository,ICountryRepository
    {
        public CountryRepository(AppDbContext context) : base(context) { }
        public async Task<Country> FindById(int id)
        {
            return await _context.Countries
                .Where(p => p.Id == id)
                .Include(p => p.Locatable)
                .FirstAsync();
        }

        public async Task<Country> FindByFullName(string fullname)
        {
            fullname = fullname.FirstCharToUpper();

            return await _context.Countries
                .Where(p => p.FullName == fullname)
                .FirstAsync();
        }
        public async Task<IEnumerable<Country>> ListAsync()
        {
           return await _context.Countries.Include(p => p.Locatable).ToListAsync();
        }

        public async Task<Country> ListByLocatableIdAsync(int locatableId) =>
            await _context.Countries
            .Where(p => p.LocatableId == locatableId)
            .Include(p => p.Locatable)
            .FirstAsync();
        
    }
}
