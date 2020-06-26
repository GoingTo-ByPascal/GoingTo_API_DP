﻿
using GoingTo_API_DP.Domain.Model.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Repositories.Business
{
    public interface IPlanRepository
    {
        Task<IEnumerable<Plan>> ListAsync();
        Task AddAsync(Plan plan);
        Task<Plan> FindById(int id);
        void Update(Plan plan);
        void Remove(Plan plan);
    }
}
