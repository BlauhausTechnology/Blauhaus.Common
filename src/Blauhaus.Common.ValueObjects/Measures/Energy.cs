using System;
using System.Text.Json.Serialization;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures
{
    public class Energy : BaseNumericValueObject<Energy>
    {
        [JsonConstructor]
        public Energy(decimal value) : base(value)
        {
        }

        [JsonIgnore]
        public decimal WattHours => Value;

        public static Energy FromWattHours(decimal wattHours)
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