using AutoMapper;
using GoingTo_API_DP.Domain.Model;
using GoingTo_API_DP.Domain.Services.Accounts;
using GoingTo_API_DP.Extensions;
using GoingTo_API_DP.Resources;
using GoingTo_API_DP.Resources.SaveResources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Controllers
{
    [Route("/api/[controller]")]
    public class TripsController : Controller
    {
        private readonly ITripService _tripService;
        private readonly IMapper _mapper;

        public TripsController(ITripService tripService, IMapper mapper)
        {
            _tripService = tripService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TripResource>> GetAllAsync()
        {
            var trips = await _tripService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Trip>, IEnumerable<TripResource>>(trips);

            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _tripService.FindById(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var tripResource = _mapper.Map<Trip, TripResource>(result.Resource);
            return Ok(tripResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] SaveTripResource resource)
        {
            var trip = _mapper.Map<SaveTripResource, Trip>(resource);
            var result = await _tripService.UpdateAsync(id, trip);

            if (!result.Success)
                return BadRequest(result.Message);
            var tripResource = _mapper.Map<Trip, TripResource>(result.Resource);
            return Ok(tripResource);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _tripService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var tripResource = _mapper.Map<Trip, TripResource>(result.Resource);
            return Ok(tripResource);
        }
    }
}
