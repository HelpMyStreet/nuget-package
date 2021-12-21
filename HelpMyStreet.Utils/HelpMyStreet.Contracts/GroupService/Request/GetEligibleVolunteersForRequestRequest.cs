using HelpMyStreet.Contracts.GroupService.Response;
using HelpMyStreet.Contracts.RequestService.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class GetEligibleVolunteersForRequestRequest : IRequest<GetEligibleVolunteersForRequestResponse>
    {
        public int ReferringGroupId { get; set; }
        public string Source { get; set; }
        public SupportActivityType SupportActivityType { get; set; }
        public string PostCode { get; set; }
    }
}
