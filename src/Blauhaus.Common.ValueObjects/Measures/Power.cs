using System;
using System.Text.Json.Serialization;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures
{
    public class Power : BaseDoubleValueObject<Power>
    {
        public Power(double value) : base(value)
        {
        }
        
        [JsonIgnore] public double MilliWatts => Watts * 1000d;
        [JsonIgnore] public double Watts => Value;
        [JsonIgnore] public double KiloWatts => Watts / 1000d;
        [JsonIgnore] public double MegaWatts => Watts / 1_000_000d;
        [JsonIgnore] public double GigaWatts => Watts / 1_000_000_000d;

        public static Power FromWatts(double watts)
        {
            return new Power(watts);
        }

        public static Power FromEnergy(Energy energy, TimeSpan elapsedTime)
        {
            var val = (energy.WattHours * 60 * 60) / elapsedTime.TotalSeconds;
            return FromWatts(val);
        }

        public Energy ToEnergy(TimeSpan elapsedTime)
        {
            return new Energy(Watts * elapsedTime.TotalHours);
        } 

        public Power Add(double otherWatts)
        {
            return new Power(Watts + otherWatts);
        }

        public override string ToString()
        {
            return Value switch
            {
                < 1 => $"{Math.Round(MilliWatts, 3)} mW",
                < 1000 => $"{Math.Round(Watts, 3)} W",
                < 1_000_000 => $"{Math.Round(KiloWatts, 3)} KW",
                < 1_000_000_000 => $"{Math.Round(MegaWatts, 3)} MW",
                _ => $"{Math.Round(GigaWatts, 3)} GW"
            };
        }
 
    }
}