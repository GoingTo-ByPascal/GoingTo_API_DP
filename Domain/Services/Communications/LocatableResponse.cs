using GoingTo_API_DP.Domain.Model.Geographic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Services.Communications
{
    public class LocatableResponse : BaseResponse<Locatable>
    {
        public LocatableResponse(string message) : base(message) { }

        public LocatableResponse(Locatable locatable) : base(locatable) { }
    }
}
