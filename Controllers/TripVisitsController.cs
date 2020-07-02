using AutoMapper;
using GoingTo_API_DP.Domain.Model;
using GoingTo_API_DP.Domain.Services.Accounts;
using GoingTo_API_DP.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Controllers
{
    [Route("/api/trips/{tripId}/visits")]
    public class TripVisitsController:Controller
    {
        private readonly IVisitService _visitService;
        private readonly IMapper _mapper;

        public TripVisitsController(IVisitService visitService, IMapper mapper)
        {
            _visitService = visitService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<VisitResource>> GetByTripId(int tripId)
        {
            var visits = await _visitService.ListByTripIdAsync(tripId);
            var resources = _mapper.Map<IEnumerable<Visit>, IEnumerable<VisitResource>>(visits);

            return resources;
        }
    }
}
