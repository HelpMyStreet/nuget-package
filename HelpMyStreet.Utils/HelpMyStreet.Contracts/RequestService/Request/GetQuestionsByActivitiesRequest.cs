using HelpMyStreet.Contracts.RequestService.Response;
using HelpMyStreet.Utils.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class GetQuestionsByActivitiesRequest : IRequest<GetQuestionsByActivtiesResponse>
    {
       public ActivitesRequest ActivitesRequest { get; set;  }
    }

    public class ActivitesRequest
    {
        public List<SupportActivities> Activities { get; set; }
    }
}
