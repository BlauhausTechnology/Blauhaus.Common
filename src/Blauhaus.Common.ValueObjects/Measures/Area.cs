using System.Text.Json.Serialization;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures;

public class Area : BaseDoubleValueObject<Area>
{
    [JsonConstructor]
    public Area(double value) : base(value)
    {
    }

    [JsonIgnore] public double MetresSquared => Value;

    public static Area FromMetresSquared(double metresSquared) => new(metresSquared);
}