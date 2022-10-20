using System;
using System.Dynamic;
using System.Globalization;
using System.Text.Json.Serialization;
using Blauhaus.Common.ValueObjects.Measures;

namespace Blauhaus.Common.ValueObjects.Base;

public abstract class BaseDoubleValueObject<T> : BaseValueObject<T, double> 
    where T : BaseValueObject<T, double>
{
    protected BaseDoubleValueObject(double value) : base(value)
    { 
    }


    [JsonIgnore]
    public static T Zero = Create(0d); 
    
    public static T Create(double value) => (T)Activator.CreateInstance(typeof(T), value); 
    public static T Create(decimal value) => (T)Activator.CreateInstance(typeof(T), Convert.ToDouble(value)); 
    public static T Create(float value) => (T)Activator.CreateInstance(typeof(T), Convert.ToDouble(value)); 
    public static T Create(int value) => (T)Activator.CreateInstance(typeof(T), Convert.ToDouble(value)); 
        
    public string Serialize() => Value.ToString(CultureInfo.InvariantCulture);
    
    public static T  Deserialize(string serialized) =>
        double.TryParse(serialized, NumberStyles.Any, CultureInfo.InvariantCulture, out var value) ?  Create(value) : Zero;

    public static bool TryDeserialize(string serialized, out T parsed)
    {
        if(decimal.TryParse(serialized, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsedValue))
        {
            parsed = Create(parsedValue);
            return true;
        }
        parsed = null!;
        return false;
    }

 
}