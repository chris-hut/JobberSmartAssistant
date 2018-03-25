using System;

namespace DialogFlow.Sdk.Models.Common
{
    public struct DatePeriod
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public static bool IsParsable(string s)
        {
            try
            {
                var splitText = s.Split('/');
                var startDate = DateTime.Parse(splitText[0]);
                var endDate = DateTime.Parse(splitText[1]);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static DatePeriod Parse(string s)
        {
            var splitText = s.Split('/');
            return new DatePeriod
            {
                Start = DateTime.Parse(splitText[0]),
                End = DateTime.Parse(splitText[1])
            };
        }
    }
}
