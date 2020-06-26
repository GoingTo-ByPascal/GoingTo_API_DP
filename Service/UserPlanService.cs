
using GoingTo_API_DP.Domain.Model.Business;
using GoingTo_API_DP.Domain.Repositories;
using GoingTo_API_DP.Domain.Repositories.Business;
using GoingTo_API_DP.Domain.Services.Business;
using GoingTo_API_DP.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Services
{
    public class UserPlanService : IUserPlanService
    {
        private readonly IUserPlanRepository _userPlanRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserPlanService(IUserPlanRepository userPlanRepository, IUnitOfWork unitOfWork)
        {
            _userPlanRepository = userPlanRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PlanUser>> ListAsync()
        {
            return await _userPlanRepository.ListAsync();
        }

        public async Task<IEnumerable<PlanUser>> ListByPlanIdAsync(int planId)
        {
            return await _userPlanRepository.ListByPlanIdAsync(planId);
        }

        public async Task<IEnumerable<PlanUser>> ListByUserIdAsync(int userId)
        {
            return await _userPlanRepository.ListByUserIdAsync(userId);
        }
        public async Task<UserPlanResponse> AssignUserPlanAsync(int userId, int planId)
        {
            try
            {
                await _userPlanRepository.AssignUserPlan(userId, planId);
                await _unitOfWork.CompleteAsync();
                PlanUser userPlan = await _userPlanRepository.FindByUserIdAndPlanId(userId, planId);

                return new UserPlanResponse(userPlan);
            }
            catch(Exception ex)
            {
                return new UserPlanResponse($"An error ocurred while assigning Plan to User {ex.Message}");
            }
        }

        public async Task<UserPlanResponse> UnassignUserPlanAsync(int userId, int planId)
        {
            try
            {
                PlanUser userPlan = await _userPlanRepository.FindByUserIdAndPlanId(userId, planId);
                _userPlanRepository.Remove(userPlan);
                await _unitOfWork.CompleteAsync();

                return new UserPlanResponse(userPlan);
            }
            catch(Exception ex)
            {
                return new UserPlanResponse($"An error ocurred while unnasigning Plan to User {ex.Message}");
            }
        }

    }
}
