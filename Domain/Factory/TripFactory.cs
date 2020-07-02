using GoingTo_API_DP.Domain.State;
using GoingTo_Library.Factory;
using GoingTo_Library.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Model.Accounts
{
    public class TripFactory : TravelableFactory<Trip>
    {
        public override Travelable CreateTravelable(Trip trip)
        {
            if (trip.StateName == "Past")
            {
                trip.SetState(new PastTripState());
                return trip;
            }
            else if(trip.StateName == "Future")
            {
                trip.SetState(new FutureTripState());
                return trip;
            }
            else
            {
                trip.SetState(new NeutralTripState());
                return trip;
            }

        }
       
    }
}
