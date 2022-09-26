using System;
using System.Globalization;
using System.Text.Json.Serialization;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures
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
        [JsonIgnore]
        public static Angle Zero = new Angle(0);


        public static Angle FromDegrees(double degrees) => new(degrees);
        public static Angle FromRadians(double radians) => new(180 / Math.PI * radians);

        public string Serialize() => Degrees.ToString(CultureInfo.InvariantCulture);
        public static Angle Deserialize(string serialized) =>
            double.TryParse(serialized, NumberStyles.Any, CultureInfo.InvariantCulture, out var degrees) ?  FromDegrees(degrees) : Zero;

        public override string ToString()
        { 
            return $"{Math.Round(Degrees, 5)} degrees";
        }
    }
}