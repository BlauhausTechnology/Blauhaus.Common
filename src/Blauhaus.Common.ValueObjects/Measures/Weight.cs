using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures
{
    public class Weight : BaseNumericValueObject<Weight>
    {
        public Weight(decimal value) : base(value)
        {
        }

        public decimal Newtons => Value;

        public static Weight FromNewtons(decimal newtons) => new Weight(newtons);
 
    }
}