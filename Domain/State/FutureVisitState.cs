using GoingTo_API_DP.Domain.Model;
using GoingTo_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain
{
    public class FutureVisitState : IState<Visit>
    {
        public void Future(Visit visit)
        {
            throw new Exception("The visit is already in future");
        }

        public void Past(Visit visit)
        {
            visit.Past();
            visit.StateName = "Past";
        }
    }
}
