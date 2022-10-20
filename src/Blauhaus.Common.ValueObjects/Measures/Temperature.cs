using System.Globalization;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures
{
    public class Temperature : BaseDoubleValueObject<Temperature>
    {
        public Temperature(double value) : base(value)
        { 
        }

        public double Kelvin => Value;
        public static Temperature FromKelvin(double kelvin) => new Temperature(kelvin);
  
    }
}