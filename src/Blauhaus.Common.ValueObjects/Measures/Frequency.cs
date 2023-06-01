using System;
using System.Text.Json.Serialization;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures;

public class Frequency : BaseDoubleValueObject<Frequency>
{
    [JsonConstructor]
    public Frequency(double value) : base(value) { }

    [JsonIgnore]
    public double Hertz => Value;
    [JsonIgnore]
    public double KiloHertz => Value / 1_000d;
    [JsonIgnore]
    public double MegaHertz => Value / 1_000_000d;
    [JsonIgnore]
    public double GigaHertz => Value / 1_000_000_000d;

    public static Frequency FromHertz(double value) => new(value);
    public static Frequency FromKiloHertz(double value) => new(value * 1_000d);
    public static Frequency FromMegaHertz(double value) => new(value * 1_000_000d);
    public static Frequency FromGigaHertz(double value) => new(value * 1_000_000_000d);

    public override string ToString()
    {
        return Value switch
        {
            < 1_000 => $"{Math.Round(Hertz, 3)} Hz",
            < 1_000_000 => $"{Math.Round(KiloHertz, 3)} KHz",
            < 1_000_000_000 => $"{Math.Round(MegaHertz, 3)} MHz",
            _ => $"{Math.Round(GigaHertz, 3)} GHz"
        };
    }
}