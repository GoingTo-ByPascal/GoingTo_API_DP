using GoingTo_API_DP.Domain.Model;
using GoingTo_Library.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.State
{
    public class NeutralVisitState : IState<Visit>
    {
        public void Future(Visit visit)
        {
            visit.StateName = "Future";
            visit.SetState(new FutureVisitState());
        }

        public void Neutral(Visit visit)
        {
            visit.StateName = "Neutral";
            visit.SetState(new NeutralVisitState());
        }

        public void Past(Visit visit)
        {
            visit.StateName = "Past";
            visit.SetState(new PastVisitState());
        }
    }
}
