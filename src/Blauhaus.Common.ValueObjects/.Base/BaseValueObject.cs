using System.Net.NetworkInformation;

namespace Blauhaus.Common.ValueObjects.Base
{

    public  class BaseValueObject<TValueObject, TValue> : BaseValueObject<TValueObject>, IValueObject<TValueObject, TValue>
        where TValueObject : class, IValueObject<TValueObject, TValue>
    {

        protected BaseValueObject()
        {
            //overload so ValueObjects can be used as EF properties
        }

        protected BaseValueObject(TValue value)
        {
            Value = value;
        }

        public TValue Value { get; } = default!;

        protected override int GetHashCodeCore()
        {
            return Value!.GetHashCode();
        }

        protected override bool EqualsCore(TValueObject other)
        {
            return Value!.Equals(other.Value);
        }

        public override string ToString()
        {
            return Value!.ToString();
        }
    }



    public abstract class BaseValueObject<TValueObject> : IValueObject<TValueObject>
        where TValueObject : class, IValueObject<TValueObject>
    {
        public bool Equals(TValueObject? other)
        {
            return other is not null && EqualsCore(other);
        }

        public override bool Equals(object obj)
        {
            if (obj is not TValueObject other || GetType() != obj.GetType())
                return false;
            return EqualsCore(other);
        }


        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        protected abstract int GetHashCodeCore();
        protected abstract bool EqualsCore(TValueObject other);

        public static bool operator ==(BaseValueObject<TValueObject>? a, BaseValueObject<TValueObject>? b)
        {
            if (a is null &&  b is null)
                return true;
            if (a is null && b is not null)
                return false;
            if (a is not null && b is null)
                return false;
            if (a is not null && b is not null)
            {
                return a.Equals(b);
            }
            return false;
        }

        public static bool operator !=(BaseValueObject<TValueObject> a, BaseValueObject<TValueObject> b)
        {
            return !(a == b);
        }

    }
}