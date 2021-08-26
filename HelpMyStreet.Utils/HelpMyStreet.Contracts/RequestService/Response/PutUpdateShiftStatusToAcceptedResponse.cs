using HelpMyStreet.Utils.Enums;

namespace HelpMyStreet.Contracts.RequestService.Response
{
    public class PutUpdateShiftStatusToAcceptedResponse
    {
        public int JobID { get; set; }
        public UpdateJobStatusOutcome Outcome { get; set; }
    }
}
