﻿using GoingTo_API_DP.Domain.Model;
using GoingTo_API_DP.Domain.State;
using GoingTo_Library;
using GoingTo_Library.State;
using Microsoft.AspNetCore.Mvc.Formatters;
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
