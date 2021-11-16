using Blauhaus.Common.Abstractions;
using System.Collections.Generic;
using System;

namespace Blauhaus.Common.ValueObjects.Base
{
    public abstract class BaseNamedValueObject<T> : BaseValueObject<T>, IHasName where T : BaseNamedValueObject<T>
    {
        
        private static readonly Dictionary<string, Func<T>> FactoryFuncs = new();

        protected BaseNamedValueObject(string name)
        {
            Name = name;
            FactoryFuncs[name] = () => (T)this;
        }

        public string Name { get; }

        public static T FromName(string name)
        {
            return FactoryFuncs.TryGetValue(name, out var factory) 
                ? factory.Invoke() 
                : throw new InvalidOperationException($"This is no {typeof(T).Name} with a name of {name}");
        }

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