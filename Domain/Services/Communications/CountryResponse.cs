using GoingTo_API_DP.Domain.Model.Geographic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Services.Communications
{
    public class CountryResponse : BaseResponse<Country>
    {
        public CountryResponse(string message) : base(message) { }
        public CountryResponse(Country country) : base(country) { }
    }
}
