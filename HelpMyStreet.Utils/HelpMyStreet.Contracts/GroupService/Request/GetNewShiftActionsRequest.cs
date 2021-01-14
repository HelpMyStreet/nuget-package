using HelpMyStreet.Contracts.GroupService.Response;
using MediatR;
using System;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class GetNewShiftActionsRequest : IRequest<GetNewShiftActionsResponse>
    {
        public Guid Guid { get; set; }
        public int ReferringGroupId { get; set; }
        public string Source { get; set; }
    }
}
