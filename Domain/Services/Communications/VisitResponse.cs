using GoingTo_API_DP.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Services.Communications
{
    public class VisitResponse : BaseResponse<Visit>
    {
        public VisitResponse(Visit resource) : base(resource)
        {
        }

        public VisitResponse(string message) : base(message)
        {
        }
    }
}
