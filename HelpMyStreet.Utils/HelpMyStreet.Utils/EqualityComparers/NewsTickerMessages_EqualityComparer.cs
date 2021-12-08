using HelpMyStreet.Utils.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace HelpMyStreet.Utils.EqualityComparers
{
    public class NewsTickerMessages_EqualityComparer : IEqualityComparer<NewsTickerMessage>
    {
        public bool Equals(NewsTickerMessage a, NewsTickerMessage b)
        {
            return a.Message == b.Message
                && a.Value == b.Value
                && a.SupportActivity == b.SupportActivity;
        }

        public int GetHashCode(NewsTickerMessage obj)
        {
            return obj.SupportActivity.GetHashCode()
                + obj.Value.GetHashCode()
                + obj.Message.GetHashCode();
        }
    }
}
