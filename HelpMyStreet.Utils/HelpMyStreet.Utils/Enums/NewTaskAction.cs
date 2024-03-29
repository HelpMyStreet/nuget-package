﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Enums
{
    public enum NewTaskAction
    {
        MakeAvailableToGroups = 1,
        NotifyMatchingVolunteers = 2,
        AssignToVolunteer = 3,
        NotifyGroupAdmins = 4,
        SetStatusToOpen = 5,
        SendRequestorConfirmation = 6
    }
}