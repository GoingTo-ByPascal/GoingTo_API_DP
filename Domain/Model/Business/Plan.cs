using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Model.Business
{
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PlanUser> PlanUsers { get; set; }

    }
}
