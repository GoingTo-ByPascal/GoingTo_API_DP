using GoingTo_API_DP.Domain.Model.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Model.Accounts
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
//      public Wallet Wallet { get; set; }
//      public int WalletId { get; set; }
        public UserProfile Profile { get; set; }
        public List<PlanUser> UserPlans { get; set; }
        public List<Trip> Trips { get; set; } = new List<Trip>();

    }
}
