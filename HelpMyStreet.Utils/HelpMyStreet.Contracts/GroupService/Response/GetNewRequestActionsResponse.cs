using HelpMyStreet.Contracts.GroupService.Request;
using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.GroupService.Response
{
    public class GetNewRequestActionsResponse
    {
        public Dictionary<int,TaskAction> Actions { get; set; }
    }
}