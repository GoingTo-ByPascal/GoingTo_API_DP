using AutoMapper;
using AutoMapper.Configuration.Annotations;
using GoingTo_API_DP.Domain.Model;
using GoingTo_API_DP.Domain.Services.Accounts;
using GoingTo_API_DP.Persistence.Repositories;
using GoingTo_API_DP.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Controllers
{
    [Route("/api/trips/{tripId}/states")]
    public class TripStateController : Controller
    {
        private readonly ITripService _tripService;
        private readonly IMapper _mapper;

        public TripStateController(ITripService tripService, IMapper mapper)
        {
            _tripService = tripService;
            _mapper = mapper;
        }

        [HttpPut("{state}")]
        public async Task<IActionResult> ChangeState(int tripId,string state)
        {
            var existingTrip = _tripService.FindById(tripId);
            if(existingTrip != null)
            {
                if (state == "Past")
                    await _tripService.TripPastState(tripId);
                else if (state == "Future")
                    await _tripService.TripFutureState(tripId);
                else if (state == "Neutral")
                    await _tripService.TripNeutralState(tripId);

                var resource = _mapper.Map<Trip, TripResource>(existingTrip.Result.Resource);

                return Ok(resource);
            }
            return BadRequest();

        }
        [HttpGet]
        public async Task<IActionResult> GetState(int tripId)
        {
            var result = await _tripService.GetTripState(tripId);
            if (!result.Success)
                return BadRequest(result.Message);
            var tripResource = _mapper.Map<Trip, TripResource>(result.Resource);
            return Ok(tripResource);
        }
    }
}
