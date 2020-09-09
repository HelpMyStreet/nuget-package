using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Response
{
    public class StatusHistory
    {
        public DateTime StatusDate { get; set; }
        public JobStatuses JobStatus { get; set; }
        public int? VolunteerUserID { get; set; }
        public int? CreatedByUserID { get; set; }
    }
}
