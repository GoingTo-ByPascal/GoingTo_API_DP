using GoingTo_API_DP.Domain.Model;
using GoingTo_API_DP.Domain.Repositories;
using GoingTo_API_DP.Domain.Repositories.Geographic;
using GoingTo_API_DP.Domain.Services.Accounts;
using GoingTo_API_DP.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Service
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepository _visitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VisitService(IVisitRepository visitRepository, IUnitOfWork unitOfWork)
        {
            _visitRepository = visitRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<VisitResponse> DeleteAsync(int id)
        {
            var existingVisit = await _visitRepository.FindById(id);
            if (existingVisit == null)
                return new VisitResponse("Visit not found");
            try
            {
                _visitRepository.Remove(existingVisit);
                await _unitOfWork.CompleteAsync();

                return new VisitResponse(existingVisit);
            }
            catch (Exception ex)
            {
                return new VisitResponse($"An error ocurred while removing place: {ex.Message}");
            }
        }

        public async Task<VisitResponse> FindById(int id)
        {
            var existingVisit = await _visitRepository.FindById(id);
            if (existingVisit == null)
                return new VisitResponse("Visit not found");
            return new VisitResponse(existingVisit);
        }

        public async Task<IEnumerable<Visit>> ListAsync()
        {
            return await _visitRepository.ListAsync();
        }

        public async Task<VisitResponse> SaveAsync(Visit visit)
        {
            try
            {
                await _visitRepository.AddAsync(visit);
                await _unitOfWork.CompleteAsync();

                return new VisitResponse(visit);
            }
            catch (Exception ex)
            {
                return new VisitResponse($"An error ocurred while saving place: {ex.Message}");
            }
        }

        public async Task<VisitResponse> UpdateAsync(int id, Visit visit)
        {
            var existingVisit = await _visitRepository.FindById(id);
            if (existingVisit == null)
                return new VisitResponse("Visit not found");
            existingVisit.Date = visit.Date;
            try
            {
                _visitRepository.Update(existingVisit);
                await _unitOfWork.CompleteAsync();

                return new VisitResponse(existingVisit);
            }
            catch (Exception ex)
            {
                return new VisitResponse($"An error ocurred while updating visit: {ex.Message}");
            }
        }
    }
}
