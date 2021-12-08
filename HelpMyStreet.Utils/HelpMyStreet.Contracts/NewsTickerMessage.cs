using System;

namespace HelpMyStreet.Contracts
{
    public class NewsTickerMessage
    {
        public string Message { get; set; }
        public Utils.Enums.SupportActivities? SupportActivity { get; set; }
        public double? Value { get; set; }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                NewsTickerMessage m = (NewsTickerMessage)obj;
                return (Message == m.Message) && (SupportActivity == m.SupportActivity) && (Value == m.Value);
            }
        }
    }


}