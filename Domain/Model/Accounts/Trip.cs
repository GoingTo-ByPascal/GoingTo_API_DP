using GoingTo_API_DP.Domain.Model.Accounts;
using GoingTo_Library;
using System.Collections.Generic;

namespace GoingTo_API_DP.Domain.Model
{
    public class Trip
    {
        private IState<Trip> CurrentState { get; set; }
        public Trip(IState<Trip> state)
        {
            CurrentState = state;
        }
        public Trip() : this(new FutureTripState()) { }

        public void SetState(IState<Trip> state)
        {
            CurrentState = state;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Visit> Visits { get; set; } = new List<Visit>();
        public string StateName { get; set; }
        public void Past()
        {
            this.CurrentState.Past(this);
        }
        public void Future()
        {
            this.CurrentState.Future(this);
        }
    }
}