using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.GroupService.Response
{
    public class GetRequestHelpFormVariantResponse
    {
        public RequestHelpFormVariant RequestHelpFormVariant { get; set; }
        public TargetGroups TargetGroups { get; set; }
        public bool AccessRestrictedByRole { get; set; }
        public bool RequestorDefinedByGroup { get; set; }
        public RequestPersonalDetails RequestorPersonalDetails { get; set; }
    }
}
