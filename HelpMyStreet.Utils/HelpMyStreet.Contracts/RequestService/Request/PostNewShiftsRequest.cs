using HelpMyStreet.Contracts.RequestService.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using HelpMyStreet.Utils.Models;
using HelpMyStreet.Utils.Enums;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class PostNewShiftsRequest : IRequest<PostNewShiftsResponse>
    {
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
