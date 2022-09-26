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