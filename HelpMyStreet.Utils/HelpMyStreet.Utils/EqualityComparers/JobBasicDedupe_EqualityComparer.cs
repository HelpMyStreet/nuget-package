using HelpMyStreet.Utils.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace HelpMyStreet.Utils.EqualityComparers
{
    public class JobBasicDedupe_EqualityComparer : IEqualityComparer<JobBasic>
    {
        public bool Equals(JobBasic a, JobBasic b)
        {
            return a.RequestID == b.RequestID && a.SupportActivity == b.SupportActivity;

        }

        public int GetHashCode(JobBasic obj)
        {
            return obj.RequestID.GetHashCode() + obj.SupportActivity.GetHashCode();
        }
    }
}
