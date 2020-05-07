using HelpMyStreet.Contracts.RequestService.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using HelpMyStreet.Utils.Models;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class PostNewRequestForHelpRequest : IRequest<PostNewRequestForHelpResponse>
    {
        public Job JobRequest { get; set; }
        public string CommunicationPreferences { get; set; }
        public string OtherDetails { get; set; }
    }
}
