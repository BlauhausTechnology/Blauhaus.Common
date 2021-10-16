using Blauhaus.Common.Abstractions;

namespace Blauhaus.Common.ValueObjects.Base
{
    public abstract class BaseNamedValueObject<T> : BaseValueObject<T>, IHasName where T : BaseNamedValueObject<T>
    {
        protected BaseNamedValueObject(string name)
        {
            Name = name;
        }

        public string Name { get; }

        #region Equality

        protected override int GetHashCodeCore()
        {
            return Name.GetHashCode();
        }

        protected override bool EqualsCore(T other)
        {
            return other.Name == Name;
        }

        public override string ToString()
        {
            return Name;
        }

        #endregion

    }
}