using System;
using System.Text.Json.Serialization;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures
{
    public class Energy : BaseDoubleValueObject<Energy>
    {
        [JsonConstructor]
        public Energy(double value) : base(value)
        {
        }
        [JsonIgnore] public double MilliWattHours => Value * 1_000d;
        [JsonIgnore] public double WattHours => Value;
        [JsonIgnore] public double KiloWattHours => Value / 1_000d;
        [JsonIgnore] public double MegaWattHours => Value / 1_000_000d;
        [JsonIgnore] public double GigaWattHours => Value / 1_000_000_000d;

        [JsonIgnore] public double WattSeconds => Value*3600d;
        [JsonIgnore] public double Joules => WattSeconds;

        public static Energy FromWattHours(double wattHours)
        {
            return new Energy(wattHours);
        }
        
        public static Energy FromWattSeconds(double wattSeconds)
        {
            return new Energy(wattSeconds/3600d);
        }


        public double CalculateAmpHours(Voltage voltage)
        {
            return WattHours / voltage.Volts;
        }
        
        public static Energy Min(Energy first, Energy second)
        {
            return first.WattHours < second.WattHours ? first : second;
        }
        public Energy Min(Energy second)
        {
            return WattHours < second.WattHours ? this : second;
        }
        
        public static Energy Max(Energy first, Energy second)
        {
            return first.WattHours > second.WattHours ? first : second;
        }
        public Energy Max(Energy second)
        {
            return WattHours > second.WattHours ? this : second;
        }

        public Power ToPower(TimeSpan elapsedTime)
        {
            return Power.FromEnergy(this, elapsedTime);
        }

        public override string ToString()
        {
            return Value switch
            {
                < 1 => $"{Math.Round(MilliWattHours, 3)} mWH",
                < 1000 => $"{Math.Round(WattHours, 3)} WH",
                < 1_000_000 => $"{Math.Round(KiloWattHours, 3)} KWH",
                < 1_000_000_000 => $"{Math.Round(MegaWattHours, 3)} MWH",
                _ => $"{Math.Round(GigaWattHours, 3)} GWH"
            };
        }
    }
 
}