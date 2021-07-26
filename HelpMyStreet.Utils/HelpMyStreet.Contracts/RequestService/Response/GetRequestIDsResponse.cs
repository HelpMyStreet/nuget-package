using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Response
{
    public class GetRequestIDsResponse
    {
        public Dictionary<int,int> JobIDsToRequestIDs { get; set; }
    }
}
