using GoingTo_API_DP.Domain.Model.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Services.Communications
{
    public class ProfileResponse : BaseResponse<UserProfile>
    {
        public UserProfile Profile { get; private set; }

        public ProfileResponse(string message) : base(message) { }

        public ProfileResponse(UserProfile profile) : base(profile) { }
    }
}
