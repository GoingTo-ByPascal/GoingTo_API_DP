﻿using GoingTo_API_DP.Domain.Model;
using GoingTo_API_DP.Domain.State;
using GoingTo_Library;
using GoingTo_Library.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain
{
    public class FutureTripState : IState<Trip>
    {
        public void Future(Trip trip)
        {
            throw new Exception("The trip is already in the future");
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
