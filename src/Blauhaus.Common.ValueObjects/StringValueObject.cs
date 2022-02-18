using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects
{
    public class StringValueObject : BaseValueObject<StringValueObject, string>
    {
        public StringValueObject(string value) : base(value)
        {
        }

    }
}