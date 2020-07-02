using GoingTo_API_DP.Domain.Model;
using GoingTo_Library.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.State
{
    public class NeutralTripState : IState<Trip>
    {
        public void Future(Trip trip)
        {
            trip.StateName = "Future";
            trip.SetState(new FutureTripState());
        }

        public void Neutral(Trip trip)
        {
            trip.StateName = "Neutral";
            trip.SetState(new NeutralTripState());
        }

        public void Past(Trip trip)
        {
            trip.StateName = "Past";
            trip.SetState(new PastTripState());
        }
    }
}
