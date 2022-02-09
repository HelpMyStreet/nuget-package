using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;

namespace HelpMyStreet.Contracts.GroupService.Response
{
    public class GetNewRequestActionsSimplifiedResponse
    {
        public Dictionary<Guid,TaskAction> Actions { get; set; }

        public Dictionary<NewTaskAction, List<int>> RequestTaskActions { get; set; }
    }
}