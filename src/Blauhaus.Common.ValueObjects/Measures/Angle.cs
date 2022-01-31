using System.Text.Json.Serialization;

namespace Blauhaus.Common.ValueObjects.Measures
{
    using Blauhaus.Common.ValueObjects.Base;
using System;

    namespace MineGame.Common.Abstractions.Values.Measures
    {
        public class Angle : BaseValueObject<Angle, double>
        {
            [JsonConstructor]
            public Angle(double degrees) : base(degrees)
            {
            }
            
            [JsonIgnore]
            public double Degrees => Value;
            [JsonIgnore]
            public double Radians => Math.PI / 180 * Degrees;


            public static Angle FromDegrees(double degrees) => new(degrees);
            public static Angle FromRadians(double radians) => new(180 / Math.PI * radians);

            public override string ToString()
            { 
                return $"{Math.Round(Degrees, 5)} degrees";
            }
        }
    }
}