using GoingTo_API_DP.Domain.Model;
using GoingTo_API_DP.Domain.State;
using GoingTo_Library.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Factory
{
    public class VisitFactory : TravelableFactory<Visit>
    {
        public override Travelable CreateTravelable(Visit visit)
        {

            if (visit.StateName == "Past")
            {
                visit.SetState(new PastVisitState());
                return visit;
            }
            else if (visit.StateName == "Future")
            {
                visit.SetState(new FutureVisitState());
                return visit;
            }
            else
            {
                visit.SetState(new NeutralVisitState());
                return visit;
            }
        }
    }
}
