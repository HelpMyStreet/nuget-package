using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class GetQuestionsByActivitiesRequest
    {
        public List<SupportActivities> SupportActivities {get;set;}
    }
}
