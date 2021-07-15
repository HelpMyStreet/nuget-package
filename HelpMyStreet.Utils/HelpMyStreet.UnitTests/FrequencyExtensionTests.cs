using System;
using System.Collections.Generic;
using System.Text;
using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Extensions;
using NUnit.Framework;

namespace HelpMyStreet.UnitTests
{
    class FrequencyExtensionTests
    {
        [Test]
        public void FrequencyDays_AllValuesCovered()
        {
            foreach (Frequency val in Enum.GetValues(typeof(Frequency)))
            {
                if (val.Equals(Frequency.Once))
                {
                    // .FrequencyDays() intentionally not defined 
                }
                else
                {
                    _ = val.FrequencyDays();
                }
            }
        }

        [Test]
        public void MaxOccurrences_AllValuesCovered()
        {
            foreach (Frequency val in Enum.GetValues(typeof(Frequency)))
            {
                _ = val.MaxOccurrences();
            }
        }
    }
}
