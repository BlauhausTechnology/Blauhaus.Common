using System;
using System.Globalization;
using System.Text.Json.Serialization;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures
{
    public class Distance : BaseValueObject<Distance, double>
    {
        [JsonConstructor]
        public Distance(double value) : base(value)
        {
        }
        
        [JsonIgnore]
        public double Millimetres => Value * 1_000_000;
        [JsonIgnore]
        public double Centimetres => Value * 100_000;
        [JsonIgnore]
        public double Metres => Value * 1_000;
        [JsonIgnore]
        public double Kilometres => Value;

        
        public static Distance FromMetres(double m) => new(m/1000d);
        public static Distance FromKilometres(double km) => new(km);


       public string Serialize() => Kilometres.ToString(CultureInfo.InvariantCulture);
        public static Distance Deserialize(string serialized) => 
            double.TryParse(serialized, NumberStyles.Any, CultureInfo.InvariantCulture, out var distance) ?  FromKilometres(distance) : Zero;


        [JsonIgnore]
        public static Distance Zero = new(0);

        public override string ToString()
        {
            if (Value < 0.0001) return $"{Math.Round(Millimetres, 3)} cm";
            if (Value < 0.001) return $"{Math.Round(Centimetres, 3)} cm";
            if(Value < 1) return $"{Math.Round(Metres, 3)} m";;
            return $"{Math.Round(Kilometres, 3)} km";
        }

    }
}