using HelpMyStreet.Contracts.RequestService.Response;
using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Models
{
    public class HelpRequest
    {
        public bool ForRequestor { get; set; }
        public bool ReadPrivacyNotice { get; set; }
        public bool AcceptedTerms { get; set; }
        public RequestPersonalDetails Requestor { get; set; }
        public RequestPersonalDetails Recipient { get; set; }
        public string SpecialCommunicationNeeds { get; set; }
        public string OtherDetails { get; set; }
        public bool ConsentForContact { get; set; }
        public int CreatedByUserId { get; set; }
    }
}
