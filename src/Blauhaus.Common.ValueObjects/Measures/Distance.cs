using System;
using System.Globalization;
using System.Text.Json.Serialization;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures
{
    public class Distance : BaseNumericValueObject<Distance>
    {
        public Distance(decimal value) : base(value)
        {
        }
        
        [JsonIgnore]
        public decimal Millimetres => Value * 1_000_000;
        [JsonIgnore]
        public decimal Centimetres => Value * 100_000;
        [JsonIgnore]
        public decimal Metres => Value * 1_000;
        [JsonIgnore]
        public decimal Kilometres => Value; 
        
        public static Distance FromMetres(decimal m) => new(m/1000m);
        public static Distance FromKilometres(decimal km) => new(km);

        public override string ToString()
        {
            switch (Value)
            {
                case < 0.0001m:
                    return $"{Math.Round(Millimetres, 3)} cm";
                case < 0.001m:
                    return $"{Math.Round(Centimetres, 3)} cm";
                case < 1m:
                    return $"{Math.Round(Metres, 3)} m";
                default:
                    return $"{Math.Round(Kilometres, 3)} km";
            }
        }
 
    }
}