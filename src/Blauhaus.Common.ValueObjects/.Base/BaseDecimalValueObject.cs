using System;
using System.Dynamic;
using System.Globalization;
using System.Text.Json.Serialization;
using Blauhaus.Common.ValueObjects.Measures;

namespace Blauhaus.Common.ValueObjects.Base;

public abstract class BaseDecimalValueObject<T> : BaseValueObject<T, decimal> 
    where T : BaseValueObject<T, decimal>
{
    protected BaseDecimalValueObject(decimal value) : base(value)
    {
        CalculationValue = decimal.ToDouble(Value);
    }


    [JsonIgnore]
    public static T Zero = Create(0);
    [JsonIgnore]
    public double CalculationValue { get; }
    
    public static T Create(decimal value) => (T)Activator.CreateInstance(typeof(T), value);
    public static T FromDouble(double calculationValue) => Create(Convert.ToDecimal(calculationValue));
        
    public string Serialize() => Value.ToString(CultureInfo.InvariantCulture);
    
    public static T  Deserialize(string serialized) =>
        decimal.TryParse(serialized, NumberStyles.Any, CultureInfo.InvariantCulture, out var value) ?  Create(value) : Zero;

    public static bool TryDeserialize(string serialized, out T parsed)
    {
        if(decimal.TryParse(serialized, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsedDecimal))
        {
            parsed = Create(parsedDecimal);
            return true;
        }
        parsed = null!;
        return false;
    }

 
}