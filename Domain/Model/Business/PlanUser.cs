using GoingTo_API_DP.Domain.Model.Accounts;
using GoingTo_Library.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Model.Business
{
    public class PlanUser : IObserver
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Plan Plan { get; set; }
        public int PlanId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }


        private IObservable P { get; set; } = null;

        public PlanUser()
        {
            this.P = Plan;
            this.Plan.RegisterObserver(this);
        }

        public void Update(object Target)
        {
            Plan plan = new Plan
            {
                Name = Target.ToString()
            };

            Console.WriteLine("OBSERVER [User]: The" + plan.Name + "Has changed");
        }

        public void StartListening(IObservable Plan)
        {
            if (this.P != null)
            {
                StopListening();
            }

            this.P = Plan;
        }

        public void StopListening()
        {
            this.P.RemoveObserver(this);
            this.P = null;
        }
    }
}
