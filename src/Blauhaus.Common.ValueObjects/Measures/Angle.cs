using System;
using System.Text.Json.Serialization;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures
{
    public class Angle : BaseNumericValueObject<Angle>
    {
        public Angle(decimal value) : base(value)
        {
        }
         
        
        [JsonIgnore]
        public decimal Degrees => Value;
        [JsonIgnore]
        public decimal Radians => Convert.ToDecimal(Math.PI / 180 * CalculationValue);

        public static Angle FromDegrees(decimal degrees) => new(degrees);
        public static Angle FromRadians(decimal radians) => FromDouble(180 / Math.PI * decimal.ToDouble(radians));

        public override string ToString()
        { 
            return $"{Math.Round(CalculationValue, 5)} degrees";
        }

    }
}