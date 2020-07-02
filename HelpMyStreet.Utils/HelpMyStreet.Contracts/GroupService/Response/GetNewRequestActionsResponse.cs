using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.GroupService.Response
{
    public class GetNewRequestActionsResponse
    {
        public Dictionary<NewTaskAction,List<int>> Actions { get; set; }
    }
}
