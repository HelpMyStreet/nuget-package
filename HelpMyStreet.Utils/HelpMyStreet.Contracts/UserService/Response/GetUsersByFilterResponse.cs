using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.UserService.Response
{
    public class GetUsersByFilterResponse
    {
        public IEnumerable<UserSummary> UserSummaries { get; set; }
    }
}
