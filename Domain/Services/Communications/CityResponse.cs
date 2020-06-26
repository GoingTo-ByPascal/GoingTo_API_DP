using GoingTo_API_DP.Domain.Model.Geographic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Services.Communications
{
    public class CityResponse : BaseResponse<City>
    {
        public CityResponse(string message) : base(message) { }
        public CityResponse(City City) : base(City) { }
    }
}
