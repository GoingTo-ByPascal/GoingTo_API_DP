using GoingTo_API_DP.Domain.Factory;
using GoingTo_API_DP.Domain.Model.Geographic;
using GoingTo_Library;
using GoingTo_Library.Factory;
using GoingTo_Library.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Model
{
    public class Visit : Travelable
    {
        public Visit()
        {
            Factory = new VisitFactory();
        }

        private IState<Visit> CurrentState { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Locatable Locatable { get; set; }
        public int LocatableId { get; set; }
        public Trip Trip { get; set; }
        public int TripId { get; set; }
        private TravelableFactory<Visit> Factory { get; set; } 
        public void SetState(IState<Visit> state)
        {
            CurrentState = state;
        }

        public void Past()
        {
            Factory.CreateTravelable(this);
            this.CurrentState.Past(this);
        }
        public void Future()
        {
            Factory.CreateTravelable(this);
            this.CurrentState.Future(this);
        }
    }
}
