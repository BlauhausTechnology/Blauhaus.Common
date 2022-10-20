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

        public static Energy FromWattHours(double wattHours)
        {
            return new Energy(wattHours);
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
    }
 
}