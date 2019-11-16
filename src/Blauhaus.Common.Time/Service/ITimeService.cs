using System;

namespace Blauhaus.Common.Time.Service
{
    public interface ITimeService
    {
        long CurrentUtcTimestampMs{ get; }
        DateTime CurrentUtcTime { get; }
        DateTimeOffset CurrentUtcOffset { get; }
    }
}