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

        public async Task<VisitResponse> AssignVisitAsync(int tripId, int locatableId)
        {
            try
            {
                await _visitRepository.AssignVisit(tripId, locatableId);
                await _unitOfWork.CompleteAsync();
                Visit visit = await _visitRepository.FindByTripIdAndLocatableId(tripId, locatableId);
                return new VisitResponse(visit);
            }
            catch (Exception ex)
            {
                return new VisitResponse($"An error ocurred while assigning Trip to Visit: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Visit>> ListAsync()
        {
            return await _visitRepository.ListAsync();
        }

        public async Task<IEnumerable<Visit>> ListByTripIdAsync(int tripId)
        {
            return await _visitRepository.ListByTripIdAsync(tripId);
        }

        public async Task<VisitResponse> SaveAsync(Visit visit)
        {
            try
            {
                visit.Neutral();
                await _visitRepository.AddAsync(visit);
                await _unitOfWork.CompleteAsync();
                return new VisitResponse(visit);
            }
            catch (Exception ex)
            {
                return new VisitResponse($"An error ocurred while saving visit: {ex.Message}");
            }
        }

        public async Task<VisitResponse> UnassignVisitAsync(int tripId, int locatableId)
        {
            try
            {
                Visit visit = await _visitRepository.FindByTripIdAndLocatableId(tripId, locatableId);
                _visitRepository.Remove(visit);
                await _unitOfWork.CompleteAsync();
                return new VisitResponse(visit);
            }
            catch (Exception ex)
            {
                return new VisitResponse($"An error ocurred while unnasigning Trip to Visit: {ex.Message}");
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

        public async Task<VisitResponse> VisitFutureState(int id)
        {
            var existingVisit = await _visitRepository.FindById(id);
            if (existingVisit == null)
                return new VisitResponse("Visit not found");
            existingVisit.Future();
            try
            {
                await _unitOfWork.CompleteAsync();
                return new VisitResponse(existingVisit);
            }
            catch (Exception ex)
            {
                return new VisitResponse($"An error ocurred while modify the state: {ex.Message}");
            }
        }

        public async Task<VisitResponse> VisitPastState(int id)
        {
            var existingVisit = await _visitRepository.FindById(id);
            if (existingVisit == null)
                return new VisitResponse("Visit not found");
            existingVisit.Past();
            try
            {
                await _unitOfWork.CompleteAsync();
                return new VisitResponse(existingVisit);
            }
            catch (Exception ex)
            {
                return new VisitResponse($"An error ocurred while modifing the state: {ex.Message}");
            }
        }
        public async Task<VisitResponse> GetVisitState(int id)
        {      
            var existingVisit = await _visitRepository.FindById(id);
            if (existingVisit == null)
                return new VisitResponse("Visit not found");
            try
            {
                await _unitOfWork.CompleteAsync();
                return new VisitResponse(existingVisit.StateName);
            }
            catch(Exception ex)
            {
                return new VisitResponse($"An error ocurred while getting the state: {ex.Message}");
            }
        }
        public async Task<VisitResponse> FindByVisitId(int id)
        {
            var existingVisit = await _visitRepository.FindById(id);
            if (existingVisit == null)
                return new VisitResponse("Visit not found");
            return new VisitResponse(existingVisit);
        }

        public async Task<VisitResponse> VisitNeutralState(int id)
        {
            var existingVisit = await _visitRepository.FindById(id);
            if (existingVisit == null)
                return new VisitResponse("Visit not found");
            existingVisit.Neutral();
            try
            {
                await _unitOfWork.CompleteAsync();
                return new VisitResponse(existingVisit);
            }
            catch (Exception ex)
            {
                return new VisitResponse($"An error ocurred while modifing the state: {ex.Message}");
            }
        }
    }
}
