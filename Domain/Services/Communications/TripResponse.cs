using GoingTo_API_DP.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Services.Communications
{
    public class TripResponse : BaseResponse<Trip>
    {
        public TripResponse(Trip resource) : base(resource)
        {
        }

        public TripResponse(string message) : base(message)
        {
        }
    }
}
