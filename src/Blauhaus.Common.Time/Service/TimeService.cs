using System;
using System.Globalization;
using Humanizer;

namespace Blauhaus.Common.Time.Service
{
    public class TimeService : ITimeService
    {
        public long CurrentUtcTimestampMs => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        public DateTime CurrentUtcTime => DateTime.UtcNow;
        public DateTimeOffset CurrentUtcOffset => DateTimeOffset.UtcNow;
        public string GetRelativeTimeString(DateTime utcDateTime, CultureInfo culture = null)
        {
            if(utcDateTime.Kind != DateTimeKind.Utc)
                throw new ArgumentException("DateTime must be UTC");

            return utcDateTime.Humanize(true, DateTime.UtcNow, culture);
        }
    }
}