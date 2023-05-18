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

        [JsonIgnore]
        public double WattHours => Value;
        public double WattSeconds => Value*3600d;
        public double Joules => WattSeconds;

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
            if (Value < 1000)
            {
                return $"{Math.Round(WattHours, 3)} Wh";
            }

            return $"{Math.Round(WattHours/1000d, 3)} KWh";

        }
    }
 
}