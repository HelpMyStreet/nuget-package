using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Extensions;
using HelpMyStreet.Utils.Models;

namespace HelpMyStreet.Contracts.RequestService.Response
{
    public class GetJobDetailsResponse
    {
        public RequestSummary RequestSummary { get; set; }
        public JobSummary JobSummary { get; set; }
        public RequestPersonalDetails Requestor { get; set; }
        public RequestPersonalDetails Recipient { get; set; }
        public List<StatusHistory> History { get; set; }
        public List<UpdateHistory> UpdateHistory { get; set; }
        public int? LastUpdatedByUserID
        { 
            get
            {
                var statusHistory = History?.OrderByDescending(x => x.StatusDate).Select(x => new { x.CreatedByUserID, DateCreated = x.StatusDate }).Take(1);
                var updateHistory = UpdateHistory?.OrderByDescending(x => x.DateCreated).Select(x => new { x.CreatedByUserID, x.DateCreated }).Take(1);

                return statusHistory.Concat(updateHistory).OrderByDescending(x => x.DateCreated).Select(x => x.CreatedByUserID).FirstOrDefault();   
            }
        }

        public JobStatusChangeReasonCodes? LastJobStatusChangeReasonCode
        {
            get 
            {
                return History?.OrderByDescending(x => x.StatusDate).First().JobStatusChangeReasonCode;
            }    
        }
    }
}
