using GoingTo_API_DP.Domain.Model.Accounts;
using GoingTo_Library;
using GoingTo_Library.Factory;
using GoingTo_Library.State;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace GoingTo_API_DP.Domain.Model
{
    public class Trip : Travelable
    {
        public Trip()
        {
            Factory = new TripFactory();
        }

        private IState<Trip> CurrentState { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Visit> Visits { get; set; } = new List<Visit>();
        private TravelableFactory<Trip> Factory { get; set; } 
        public void SetState(IState<Trip> state)
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