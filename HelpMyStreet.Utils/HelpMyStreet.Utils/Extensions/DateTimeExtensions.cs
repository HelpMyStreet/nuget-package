﻿using HelpMyStreet.Utils.Utils;
using System;

namespace HelpMyStreet.Utils.Extensions
{
    public static class DateTimeExtensions
    {
        public static string FriendlyFutureDate(this DateTime dateTimeDue)
        {
            return new DateTimeUtils(new MockableDateTime()).FriendlyFutureDate(dateTimeDue);
        }

        public static string FriendlyPastDate(this DateTime dateTimeDue)
        {
            return new DateTimeUtils(new MockableDateTime()).FriendlyPastDate(dateTimeDue);
        }
    }
}
