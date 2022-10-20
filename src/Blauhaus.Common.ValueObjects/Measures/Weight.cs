using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures
{
    public class Weight : BaseDoubleValueObject<Weight>
    {
        public Weight(double value) : base(value)
        {
        }

        public double Newtons => Value;

        public static Weight FromNewtons(double newtons) => new Weight(newtons);
 
    }
}