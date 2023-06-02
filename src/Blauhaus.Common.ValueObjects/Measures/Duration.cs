using System;
using System.Globalization;
using System.Text.Json.Serialization;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures;

public class Duration : BaseDoubleValueObject<Duration>
{
    public Duration(double value) : base(value) { }


    [JsonIgnore] public long Ticks => (long)Value;
    [JsonIgnore] public double Nanoseconds => Value * 100;
    [JsonIgnore] public double Microseconds => Value / 10;
    [JsonIgnore] public double Milliseconds => Value / 10_000;
    [JsonIgnore] public double Seconds => Value / 10_000_000;
    [JsonIgnore] public double Minutes => Value / 600_000_000;
    [JsonIgnore] public double Hours => Value / 36_000_000_000;
    [JsonIgnore] public double Days => Value / 864_000_000_000;
    

    public static Duration FromTimespan(TimeSpan t) => new(t.Ticks);
    public static Duration FromTicks(long ticks) => new(ticks);
    public static Duration FromNanoseconds(double nanseconds) => new(nanseconds / 100d);
    public static Duration FromMicroseconds(double microseconds) => new(microseconds * 10d);
    public static Duration FromMilliseconds(double milliseconds) => new(milliseconds * 10_000d);
    public static Duration FromSeconds(double seconds) => new(seconds * 10_000_000);
    public static Duration FromMinutes(double minutes) => new(minutes * 600_000_000);
    public static Duration FromHours(double hours) => new(hours * 36_000_000_000);
    public static Duration FromDays(double days) => new(days * 864_000_000_000);



    public TimeSpan ToTimeSpan => TimeSpan.FromTicks(Ticks);

    public override string ToString()
    {
        if (Days > 1)
            return $"{Math.Round(Days, 2).ToString(CultureInfo.InvariantCulture)} days";
        if (Hours > 1)
            return $"{Math.Round(Hours, 2).ToString(CultureInfo.InvariantCulture)} hours";
        if (Minutes > 1)
            return $"{Math.Round(Minutes, 2).ToString(CultureInfo.InvariantCulture)} minutes";
        if (Seconds > 1)
            return $"{Math.Round(Seconds, 2).ToString(CultureInfo.InvariantCulture)} seconds";
        if (Milliseconds > 1)
            return $"{Math.Round(Milliseconds, 2).ToString(CultureInfo.InvariantCulture)} milliseconds";
        if (Microseconds > 1)
            return $"{Math.Round(Microseconds, 2).ToString(CultureInfo.InvariantCulture)} microseconds";

        return $"{Nanoseconds.ToString(CultureInfo.InvariantCulture)} nanoseconds";
         
    }
}