using GoingTo_API_DP.Domain.Model.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Model.Geographic
{
    public class Country
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }

        public int LocatableId { get; set; }
        public Locatable Locatable { get; set; }
        public IList<UserProfile> Profiles { get; set; } = new List<UserProfile>();
        public IList<City> Cities { get; set; } = new List<City>();

    }
}
