using System;

namespace Blauhaus.Common.Time.Service
{
    public class TimeService : ITimeService
    {
        public long CurrentUtcTimestampMs => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        public DateTime CurrentUtcTime => DateTime.UtcNow;
    }
}