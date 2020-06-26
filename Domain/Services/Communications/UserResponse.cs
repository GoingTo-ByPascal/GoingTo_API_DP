using GoingTo_API_DP.Domain.Model.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Domain.Services.Communications
{
    public class UserResponse : BaseResponse<User>
    {
        public UserResponse(string message) : base(message) { }
        public UserResponse(User user) : base(user) { }

    }
}
