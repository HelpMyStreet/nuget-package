using HelpMyStreet.Contracts.GroupService.Response;
using HelpMyStreet.Contracts.RequestService.Request;
using HelpMyStreet.Utils.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class SupportActivityType
    {
        public SupportActivities SupportActivity { get; set; }
    }
    public class GetGroupActivityCredentialsRequest : IRequest<GetGroupActivityCredentialsResponse>
    {
        public int GroupId { get; set; }
        public SupportActivityType SupportActivityType { get; set; }        
    }
}
