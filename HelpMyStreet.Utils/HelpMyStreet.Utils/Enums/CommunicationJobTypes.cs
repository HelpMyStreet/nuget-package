using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Response
{
    public enum CommunicationJobTypes
    {
        SendWelcomeMessage = 1,
        SendRegistrationChasers = 2,
        SendNewTaskNotification = 3,
        SendOpenTaskDigest = 4,
        SendTaskStateChangeUpdate = 5,
        PostYotiCommunication = 6,
        SendTaskReminder = 7,
        InterUserMessage = 8,
        NewCredentials = 9,
        NewTaskPendingApprovalNotification = 10,
        RequestorTaskConfirmation = 11,
        TaskDetail = 12,
        SendNewRequestNotification = 13,
        SendShiftReminder = 14,
        GroupWelcome = 15,
        NewUserNotification = 16,
        InProgressReminder = 17,
        JobsDueTomorrow = 18,
        TaskAppliedForNotification = 19,
        ImpendingUserDeletion = 20,
        UserDeleted = 21
    }
}
