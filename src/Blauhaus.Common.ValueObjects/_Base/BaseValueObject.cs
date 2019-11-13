using System;

namespace Blauhaus.Common.ValueObjects._Base
{

    public  class BaseValueObject<TValueObject, TValue> : BaseValueObject<TValueObject>, IValueObject<TValueObject, TValue>
        where TValueObject : class, IValueObject<TValueObject, TValue>
    {
        protected BaseValueObject(TValue value)
        {
            Value = value;
        }

        public TValue Value { get; }
        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        protected override bool EqualsCore(TValueObject other)
        {
            return Value.Equals(other.Value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }



    public abstract class BaseValueObject<TValueObject> : IValueObject<TValueObject>
        where TValueObject : class, IValueObject<TValueObject>
    {
        public bool Equals(TValueObject other)
        {
            return EqualsCore(other);
        }

        public override bool Equals(object obj)
        {
            TValueObject other = obj as TValueObject;
            if ((object) other == null || GetType() != obj.GetType())
                return false;
            return EqualsCore(other);
        }


        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        protected abstract int GetHashCodeCore();
        protected abstract bool EqualsCore(TValueObject other);

        public static bool operator ==(BaseValueObject<TValueObject> a, BaseValueObject<TValueObject> b)
        {
            if ((object) a == null && (object) b == null)
                return true;
            if ((object) a == null || (object) b == null)
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(BaseValueObject<TValueObject> a, BaseValueObject<TValueObject> b)
        {
            return !(a == b);
        }

    }
}