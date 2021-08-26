using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;

namespace HelpMyStreet.Contracts.GroupService.Response
{
    public class GetNewShiftActionsResponse
    {
        public Dictionary<NewTaskAction, List<int>> TaskActions { get; set; }
    }
}