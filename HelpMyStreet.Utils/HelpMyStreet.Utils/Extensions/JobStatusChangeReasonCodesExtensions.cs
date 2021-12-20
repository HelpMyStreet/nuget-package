using HelpMyStreet.Utils.Enums;

namespace HelpMyStreet.Utils.Extensions
{
    public static class JobStatusChangeReasonCodesExtensions
    {
        public static bool TriggersStatusChangeEmail(this JobStatusChangeReasonCodes role)
        {
            return role switch
            {
                JobStatusChangeReasonCodes.AutoProgressingOverdueRepeats => true,
                JobStatusChangeReasonCodes.AutoProgressingJobsPastDueDates => true,
                JobStatusChangeReasonCodes.AutoProgressingShifts => false,
                JobStatusChangeReasonCodes.UserChange => true,
                JobStatusChangeReasonCodes.AutoProgressNewToOpen => false,
                _ => false
            };
        }
    }
}
