using System;

namespace Blauhaus.Common.ValueObjects.Base
{

    public interface IValueObject<TValueObject, out TValue> : IValueObject<TValueObject>
    {
        TValue Value { get; }
    } 


    public interface IValueObject<TValueObject> : IEquatable<TValueObject>
    {
        
    }
}