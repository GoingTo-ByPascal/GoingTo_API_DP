using GoingTo_API_DP.Domain.Model.Geographic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Services.Communications
{
    public class PlaceResponse : BaseResponse<Place>
    {
        public PlaceResponse(string message) : base(message) { }
        public PlaceResponse(Place place) : base(place) { }

    }
}
