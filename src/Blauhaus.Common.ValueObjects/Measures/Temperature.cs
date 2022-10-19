using System.Globalization;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures
{
    public class Temperature : BaseNumericValueObject<Temperature>
    {
        public Temperature(decimal value) : base(value)
        { 
        }

        public decimal Kelvin => Value;
        public static Temperature FromKelvin(decimal kelvin) => new Temperature(kelvin);
  
    }
}