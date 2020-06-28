using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoingTo_Library.Observer;

namespace GoingTo_API_DP.Domain.Model.Business
{
    public class Plan : IObservable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<PlanUser> PlanUsers { get; set; }

        private List<IObserver> Observers { get; set; }

        public Plan()
        {
            Observers = new List<IObserver>();
        }

        public void RegisterObserver(IObserver Observer)
        {
            this.Observers.Add(Observer);
        }

        public void RemoveObserver(IObserver Observer)
        {
            this.Observers.Remove(Observer);
        }

        public void NotifyObservers()
        {
            foreach (IObserver observer in Observers)
            {
                observer.Update(this);
            }
        }
    }
}
