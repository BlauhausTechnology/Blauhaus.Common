using System;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures
{
    public class Distance : BaseValueObject<Distance, double>
    {
        public Distance(double km) : base(km)
        {
        }
        
        public double Millimetres => Value * 1_000_000;
        public double Centimetres => Value * 100_000;
        public double Metres => Value * 1_000;
        public double Kilometres => Value;


        public override string ToString()
        {
            if (Value < 0.0001) return $"{Math.Round(Millimetres, 3)} cm";
            if (Value < 0.001) return $"{Math.Round(Centimetres, 3)} cm";
            if(Value < 1) return $"{Math.Round(Metres, 3)} m";;
            return $"{Math.Round(Kilometres, 3)} km";
        }
    }
}