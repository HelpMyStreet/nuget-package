using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Models;

namespace HelpMyStreet.Contracts.RequestService.Response
{
    public class GetJobSummaryResponse
    {
        public RequestSummary RequestSummary { get; set; }
        public JobSummary JobSummary { get; set; }
        public int RequestID { get; set; }
        public RequestType RequestType { get; set; }
    }
}
