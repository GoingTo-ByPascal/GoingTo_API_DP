using AutoMapper;
using GoingTo_API_DP.Domain.Model;
using GoingTo_API_DP.Domain.Services.Accounts;
using GoingTo_API_DP.Extensions;
using GoingTo_API_DP.Resources;
using GoingTo_API_DP.Resources.SaveResources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Controllers
{
    [Route("/api/users/{userId}/trips")]
    public class UserTripsController : Controller
    {
        private readonly ITripService _tripService;
        private readonly IMapper _mapper;

        public UserTripsController(ITripService tripService, IMapper mapper)
        {
            _tripService = tripService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TripResource>> GetByUserId(int userId)
        {
            var trips = await _tripService.ListByUserIdAsync(userId);
            var resources = _mapper
                .Map<IEnumerable<Trip>, IEnumerable<TripResource>>(trips);
            return resources;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateUserTrip(int userId, [FromBody] SaveTripResource resource )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var trip = _mapper.Map<SaveTripResource, Trip>(resource);
            trip.UserId = userId;
            var result = await _tripService.SaveAsync(trip);

            if (!result.Success)
                return BadRequest(result.Message);

            var tripResource = _mapper.Map<Trip, TripResource>(result.Resource);
            return Ok(tripResource);
        }
    }
}
