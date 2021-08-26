using HelpMyStreet.Contracts.RequestService.Response;
using MediatR;
using System;
using System.Collections.Generic;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class PostNewShiftsRequest : IRequest<PostNewShiftsResponse>
    {
        public Guid Guid { get; set; }
        public string OtherDetails { get; set; }        
        public int CreatedByUserId { get; set; }        
        public int ReferringGroupId { get; set; }
        public string Source { get; set; }
        public SingleLocationRequest Location { get; set; }
        public DateTime StartDate { get; set; }
        public int ShiftLength { get; set; }
        public List<SupportActivityCountRequest> SupportActivitiesCount { get; set; }
    }
}
