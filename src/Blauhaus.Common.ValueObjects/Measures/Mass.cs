using System.Globalization;
using System.Text.Json.Serialization;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures;

public sealed class Mass : BaseNumericValueObject<Mass>
{
    [JsonConstructor]
    public Mass(decimal value) : base(value)
    {
    }

    [JsonIgnore]
    public decimal  Kilograms => Value;
    public static Mass FromKilograms(decimal kilograms) => new(kilograms);
     
    public override string ToString()
    {
        return Kilograms.ToString(CultureInfo.InvariantCulture) + "kg";
    }
 
        
}