using HelpMyStreet.Utils.Enums;
using Microsoft.Extensions.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Utils
{
    public class DateTimeUtils
    {
        private readonly ISystemClock _systemClock;

        public DateTimeUtils(ISystemClock systemClock)
        {
            _systemClock = systemClock;
        }

        public string FriendlyFutureDate(DateTime dateTimeDue)
        {
            DateTime dueDate = dateTimeDue.Date;
            DateTime today = _systemClock.UtcNow.Date;

            int daysUntilDate = (int)dueDate.Subtract(today).TotalDays;

            return (daysUntilDate switch
            {
                int i when i < -14 => $"{-1 * i / 7} weeks ago",
                int i when i < -1 => $"{-1 * i} days ago",
                -1 => "yesterday",
                0 => "today",
                1 => "tomorrow",
                int i when i <= 6 => $"on {dueDate.DayOfWeek}",
                int i when i <= 13 => $"next {dueDate.DayOfWeek}",
                int i when i >= 14 => $"in {i / 7} weeks",
                _ => $"on {dateTimeDue:dd/MM/yyyy}"
            });
        }

        public string GetDateSuffix(DateTime dateTime)
        {
            int i = dateTime.Day;
            var appendage = "";
            if (i % 10 == 1 && i != 11)
            {
                appendage = "st";
            }
            else if (i % 10 == 2 && i != 12)
            {
                appendage = "nd";
            }
            else if (i % 10 == 3 && i != 13)
            {
                appendage = "rd";
            }
            else
            {
                appendage = "th";
            }
            return appendage;
        }

        public string ShiftyDate(DateTime dateTime)
        {
            var appendage = GetDateSuffix(dateTime);
            return $"{dateTime: ddd}, {dateTime: d}{appendage} {dateTime: MMM yyyy}";
        }

        public string ShiftyTime(DateTime dateTime)
        {
            return $"{dateTime: h:mmtt}";
        }
        public string FriendlyPastDate(DateTime dateTimeDue)
        {
            DateTime dueDate = dateTimeDue.Date;
            DateTime today = _systemClock.UtcNow.Date;

            int daysUntilDue = (int)dueDate.Subtract(today).TotalDays;

            return (daysUntilDue switch
            {
                int i when i < -13 => $"{-1 * i / 7} weeks ago",
                int i when i < -6 => $"last {dueDate.DayOfWeek}",
                int i when i < -1 => $"on {dueDate.DayOfWeek}",
                -1 => "yesterday",
                0 => "today",
                _ => $"on {dateTimeDue:dd/MM/yyyy}"
            });
        }

        public string JobDueDate(DateTime dateTimeDue, DueDateType dueDateType)
        {
            DateTime dueDate = dateTimeDue.Date;
            DateTime today = _systemClock.UtcNow.Date;

            int daysUntilDue = (int)dueDate.Subtract(today).TotalDays;

            if (daysUntilDue < 1) return "Due urgently";

            if (dueDateType == DueDateType.On)
            {
                return $"Required on {dateTimeDue:dd/MM/yyyy}";
            }
            else
            {
                return (daysUntilDue switch
                {
                    int i when i < 14 => "Due soon",
                    int i when i >= 14 => $"Due in {i / 7} weeks",
                    _ => $"Due on {dateTimeDue:dd/MM/yyyy}"
                });
            }
        }
    }
}
