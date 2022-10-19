using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures
{
    public class Volume : BaseNumericValueObject<Volume>
    {
        public Volume(decimal value) : base(value)
        {
        }

        public decimal GramsPerCentimetreCubed => Value;

    }
}