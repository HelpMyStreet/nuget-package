using System;
using System.Collections.Generic;

namespace HelpMyStreet.Contracts.GroupService.Response
{
    public class GetNewShiftActionsResponse
    {
        public Dictionary<Guid,TaskAction> Actions { get; set; }
    }
}