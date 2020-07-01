using GoingTo_API_DP.Domain.Model;
using GoingTo_Library;
using GoingTo_Library.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain
{
    public class PastTripState : IState<Trip>
    {
        public void Future(Trip trip)
        {
            trip.StateName = "Future";
            trip.SetState(new FutureTripState());
        }

        public void Past(Trip trip)
        {
            throw new Exception("The trip is already in the past");
        }
    }
}
