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
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TripService(ITripRepository tripRepository, IUnitOfWork unitOfWork)
        {
            _tripRepository = tripRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TripResponse> DeleteAsync(int id)
        {
            var existingTrip = await _tripRepository.FindById(id);
            if (existingTrip == null)
                return new TripResponse("Trip not found");
            try
            {
                _tripRepository.Remove(existingTrip);
                await _unitOfWork.CompleteAsync();

                return new TripResponse(existingTrip);
            }
            catch(Exception ex)
            {
                return new TripResponse($"An error ocurred while removing trip: {ex.Message}");
            }
        }

        public async Task<TripResponse> FindById(int id)
        {
            var existingTrip = await _tripRepository.FindById(id);
            if (existingTrip == null)
                return new TripResponse("Trip not found");
            return new TripResponse(existingTrip);
            
        }

        public async Task<IEnumerable<Trip>> ListAsync()
        {
            return await _tripRepository.ListAsync();
        }

        public async Task<IEnumerable<Trip>> ListByUserIdAsync(int userId)
        {
            return await _tripRepository.ListByUserIdAsync(userId);
        }

        public async Task<TripResponse> SaveAsync(Trip trip)
        {
            try
            {
                await _tripRepository.AddAsync(trip);
                await _unitOfWork.CompleteAsync();

                return new TripResponse(trip);
            }
            catch(Exception ex)
            {
                return new TripResponse($"An error ocurred while saving this trip: {ex.Message}");
            }
        }

        public async Task<TripResponse> UpdateAsync(int id, Trip trip)
        {
            var existingTrip = await _tripRepository.FindById(id);
            if (existingTrip == null)
                return new TripResponse("Trip not found");
            existingTrip.Description = trip.Description;
            existingTrip.Name = trip.Name;
            try
            {
                _tripRepository.Update(existingTrip);
                await _unitOfWork.CompleteAsync();

                return new TripResponse(existingTrip);
            }
            catch (Exception ex)
            {
                return new TripResponse($"An error ocurred while updating this trip: {ex.Message}");
            }


        }
    }
}
