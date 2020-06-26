﻿
using GoingTo_API_DP.Domain.Model.Business;
using GoingTo_API_DP.Domain.Persistence.Context;
using GoingTo_API_DP.Domain.Repositories.Business;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Persistence.Repositories
{
    public class PlanRepository : BaseRepository, IPlanRepository
    {
        public PlanRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Plan plan)
        {
            await _context.Plans.AddAsync(plan);
        }

        public async Task<Plan> FindById(int id)
        {
            return await _context.Plans.FindAsync(id);
        }

        public async Task<IEnumerable<Plan>> ListAsync()
        {
            return await _context.Plans.ToListAsync();
        }

        public void Remove(Plan plan)
        {
            _context.Plans.Remove(plan);
        }

        public void Update(Plan plan)
        {
            _context.Plans.Update(plan);
        }
    }
}
