using GoingTo_API_DP.Domain.Model.Business;
using GoingTo_API_DP.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Services.Business
{
    public interface IUserPlanService
    {
        Task<IEnumerable<PlanUser>> ListAsync();
        Task<IEnumerable<PlanUser>> ListByUserIdAsync(int userId);
        Task<IEnumerable<PlanUser>> ListByPlanIdAsync(int planId);
        Task<UserPlanResponse> AssignUserPlanAsync(int userId, int planId);
        Task<UserPlanResponse> UnassignUserPlanAsync(int userId, int planId);
        
    }
}
