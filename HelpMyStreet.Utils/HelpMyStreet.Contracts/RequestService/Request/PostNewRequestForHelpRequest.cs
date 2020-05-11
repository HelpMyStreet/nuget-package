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
        public bool ForRequestor { get; set; }
        public bool ReadPrivacyNotice { get; set; }
        public bool AcceptedTerms { get; set; }
        public RequestPersonalDetails Requestor { get; set; }
        public RequestPersonalDetails Recipient { get; set; }
        public string CommunicationPreferences { get; set; }
        public string OtherDetails { get; set; }
        public List<Job> Jobs { get; set; }  
    }
}
