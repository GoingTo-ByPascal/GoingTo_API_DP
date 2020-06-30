using GoingTo_API_DP.Domain.Model;
using GoingTo_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain
{
    public class PastVisitState : IState<Visit>
    {
        public void Future(Visit visit)
        {
            visit.StateName = "Future";
            visit.SetState(new FutureVisitState());
        }

        public void Past(Visit visit)
        {
            throw new Exception("The visit is already in past");
        }
    }
}
