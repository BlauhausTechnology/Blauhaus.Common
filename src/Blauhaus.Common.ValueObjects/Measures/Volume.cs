using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures
{
    public class Volume : BaseDoubleValueObject<Volume>
    {
        public Volume(double value) : base(value)
        {
        }

        public double GramsPerCentimetreCubed => Value;

    }
}