using AutoMapper;
using GoingTo_API_DP.Domain.Model;
using GoingTo_API_DP.Domain.Services.Accounts;
using GoingTo_API_DP.Domain.Services.Communications;
using GoingTo_API_DP.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Controllers
{
    [Route("/api/visits/{visitId}/states")]
    public class VisitStatesController : Controller
    {
        private readonly IVisitService _visitService;
        private readonly IMapper _mapper;

        public VisitStatesController(IVisitService visitService, IMapper mapper)
        {
            _visitService = visitService;
            _mapper = mapper;
        }

        [HttpPut("{state}")]
        public async Task<IActionResult> ChangeState(int visitId, string state)
        {
            var existingTrip = _visitService.FindByVisitId(visitId);
            if (existingTrip != null)
            {
                if (state == "Past" || state == "past")
                    await _visitService.VisitPastState(visitId);
                await _visitService.VisitFutureState(visitId);

                var resource = _mapper.Map<Visit, VisitResource>(existingTrip.Result.Resource);

                return Ok(resource);
            }
            return BadRequest();

        }
    }
   
}
