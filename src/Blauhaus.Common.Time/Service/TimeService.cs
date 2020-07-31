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
        public DateTime CurrentLocalTime => DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Local);

        public string GetRelativeTimeString(DateTime utcDateTime, CultureInfo culture = null)
        {
            if(utcDateTime.Kind != DateTimeKind.Utc)
                throw new ArgumentException("DateTime must be UTC");

            return utcDateTime.Humanize(true, DateTime.UtcNow, culture);
        }

        public string GetTimeSpanString(TimeSpan timeSpan, CultureInfo culture, int precision = 1)
        {
            return timeSpan.Humanize(precision, false, culture);
        }
    }
}