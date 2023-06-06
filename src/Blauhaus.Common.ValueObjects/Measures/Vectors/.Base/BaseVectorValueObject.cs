using System;
using Blauhaus.Common.ValueObjects.Measures;
using System.Globalization;

namespace Blauhaus.Common.ValueObjects.Base;

public class BaseVectorValueObject<TValueObject, TVector> : BaseValueObject<TValueObject>
    where TValueObject : BaseVectorValueObject<TValueObject, TVector>
    where TVector : BaseDoubleValueObject<TVector>
{
    public BaseVectorValueObject(TVector x, TVector y, TVector z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public TVector X { get; }
    public TVector Y { get; }
    public TVector Z { get; }
    
    public static TValueObject Create(TVector x, TVector y, TVector z) => 
        (TValueObject)Activator.CreateInstance(typeof(TValueObject), x,y,z); 
    
    public string Serialize() => $"{X.Serialize()}|{Y.Serialize()}|{Z.Serialize()}";

    public static TValueObject Deserialize(string serialized)
    {
        string[] stringValues = serialized.Split('|');

        return (TValueObject)Activator.CreateInstance(typeof(TValueObject),
            Activator.CreateInstance(typeof(TVector), double.TryParse(stringValues[0], NumberStyles.Any, CultureInfo.InvariantCulture, out double x) ? x : 0),
            Activator.CreateInstance(typeof(TVector), double.TryParse(stringValues[1], NumberStyles.Any, CultureInfo.InvariantCulture, out double y) ? y : 0),
            Activator.CreateInstance(typeof(TVector), double.TryParse(stringValues[2], NumberStyles.Any, CultureInfo.InvariantCulture, out double z) ? z : 0));
    }
     
    protected override int GetHashCodeCore()
    {
        return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
    }

    protected override bool EqualsCore(TValueObject other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
    }
}