﻿namespace HelpMyStreet.Utils.Enums
{
    public enum UpdateJobStatusOutcome
    {
        Success = 1,
        Unauthorized = 2,
        BadRequest = 3,
        AlreadyInThisStatus = 4,
        NoLongerAvailable = 5
    }
}