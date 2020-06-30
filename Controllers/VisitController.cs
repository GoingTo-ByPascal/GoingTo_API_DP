using AutoMapper;
using GoingTo_API_DP.Domain.Model.Geographic;
using GoingTo_API_DP.Domain.Services.Accounts;
using GoingTo_API_DP.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Controllers
{
    [Route("/api/trips/{tripId}/locatables")]
    public class VisitController : Controller
    {
        private readonly IVisitService _visitService;
        private readonly IMapper _mapper;

        public VisitController(IVisitService visitService, IMapper mapper)
        {
            _visitService = visitService;
            _mapper = mapper;
        }

        [HttpPost("{locatableId}")]
        public async Task<IActionResult> AssignVisit(int tripId, int locatableId)
        {
            var result = await _visitService.AssignVisitAsync(tripId, locatableId);
            if (!result.Success)
                return BadRequest(result.Message);
            var locatableResource = _mapper.Map<Locatable, LocatableResource>(result.Resource.Locatable);
            return Ok(locatableResource);

        }

        [HttpDelete("{locatableId}")]
        public async Task<IActionResult> UnassignVisit(int tripId, int locatableId)
        {
            var result = await _visitService.UnassignVisitAsync(tripId, locatableId);
            if (!result.Success)
                return BadRequest(result.Message);
            var locatableResource = _mapper.Map<Locatable, LocatableResource>(result.Resource.Locatable);
            return Ok(locatableResource);
        }
    }
}
