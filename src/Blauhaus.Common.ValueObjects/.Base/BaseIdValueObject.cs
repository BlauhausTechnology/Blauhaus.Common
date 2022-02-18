using System;

namespace Blauhaus.Common.ValueObjects.Base
{
    public abstract class BaseIdValueObject<T> : BaseValueObject<T> where T : BaseIdValueObject<T>
    {
        protected BaseIdValueObject(string name, Guid id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; }
        public Guid Id { get; }


        protected override int GetHashCodeCore()
        {
            return Id.GetHashCode();
        }

        protected override bool EqualsCore(T other)
        {
            return Id == other.Id;
        }
    }
}