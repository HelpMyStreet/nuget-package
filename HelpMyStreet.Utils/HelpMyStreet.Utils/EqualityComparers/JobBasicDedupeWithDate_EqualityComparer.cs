using HelpMyStreet.Utils.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace HelpMyStreet.Utils.EqualityComparers
{
    public class JobBasicDedupeWithDate_EqualityComparer : IEqualityComparer<JobBasic>
    {
        public bool Equals(JobBasic a, JobBasic b)
        {
            return a.RequestID == b.RequestID
                && a.SupportActivity == b.SupportActivity
                && a.DueDateType == b.DueDateType
                && a.DueDate == b.DueDate
                && (a.NotBeforeDate ?? DateTime.MinValue) == (b.NotBeforeDate ?? DateTime.MinValue);
        }

        public int GetHashCode(JobBasic obj)
        {
            return obj.RequestID.GetHashCode()
                + obj.SupportActivity.GetHashCode()
                + obj.DueDateType.GetHashCode()
                + obj.DueDate.GetHashCode()
                + obj.NotBeforeDate.GetHashCode();
        }
    }
}
