using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Response
{
    public class PostRequestForHelpResponse
    {
        public List<int> RequestIDs { get; set; }
        public Fulfillable Fulfillable { get; set; }
    }
}
