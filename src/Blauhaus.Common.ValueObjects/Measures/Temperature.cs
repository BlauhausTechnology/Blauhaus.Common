using System.Globalization;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures
{
    public class Temperature : BaseValueObject<Temperature>
    {
        public Temperature(double kelvin)
        {
            Kelvin = kelvin;
        }

        public double Kelvin { get; }


        public static Temperature FromKelvin(double kelvin) => new Temperature(kelvin);

        public string Serialize() => Kelvin.ToString(CultureInfo.InvariantCulture);
        public static Temperature Deserialize(string serialized) 
            => double.TryParse(serialized, NumberStyles.Any, CultureInfo.InvariantCulture, out var kelvin) ?  FromKelvin(kelvin) :FromKelvin(0);

        
        protected override int GetHashCodeCore()
        {
            return Kelvin.GetHashCode();
        }

        protected override bool EqualsCore(Temperature other)
        {
            return other.Kelvin == Kelvin;
        }
    }
}