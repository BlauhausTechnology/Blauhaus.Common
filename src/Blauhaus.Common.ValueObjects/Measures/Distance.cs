using System;
using System.Globalization;
using System.Text.Json.Serialization;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures
{
    public class Distance : BaseDoubleValueObject<Distance>
    {
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

        public override string ToString()
        {
            return Math.Abs(Value) switch
            {
                < 0.0001 => $"{Math.Round(Millimetres, 3)} cm",
                < 0.001 => $"{Math.Round(Centimetres, 3)} cm",
                < 1 => $"{Math.Round(Metres, 3)} m",
                _ => $"{Math.Round(Kilometres, 3)} km"
            };
        }
 
    }
}