using HelpMyStreet.Contracts.RequestService.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using HelpMyStreet.Utils.Models;
using HelpMyStreet.Utils.Enums;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class PostNewRequestForHelpShiftRequest : IRequest<PostNewRequestForHelpShiftResponse>
    {
        public string OtherDetails { get; set; }        
        public int CreatedByUserId { get; set; }        
        public int ReferringGroupId { get; set; }
        public string Source { get; set; }
        public string LocationRef { get; set; }
        public DateTime StartDate { get; set; }
        public int ShiftLength { get; set; }
        public Dictionary<SupportActivities, int> DictSupportActivities { get; set; }
    }
}
