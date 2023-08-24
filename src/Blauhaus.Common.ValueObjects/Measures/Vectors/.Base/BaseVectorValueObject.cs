using System;
using System.Globalization;
using System.Numerics;
using System.Runtime;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures.Vectors.Base;

public abstract class BaseVectorValueObject<TValueObject, TVector> : BaseValueObject<TValueObject>
    where TValueObject : BaseVectorValueObject<TValueObject, TVector>
    where TVector : BaseDoubleValueObject<TVector>
{
    protected BaseVectorValueObject(TVector x, TVector y, TVector z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    protected BaseVectorValueObject(double x, double y, double z)
    {
        X = (TVector)Activator.CreateInstance(typeof(TVector), x);
        Y = (TVector)Activator.CreateInstance(typeof(TVector), y);
        Z = (TVector)Activator.CreateInstance(typeof(TVector), z);
    }

    public TVector X { get; }
    public TVector Y { get; }
    public TVector Z { get; }

    public Vector3 ToVector3()
    {
        return new Vector3((float)X.Value, (float)Y.Value, (float)Z.Value);
    }
    
    public static TValueObject Create(TVector x, TVector y, TVector z) => 
        (TValueObject)Activator.CreateInstance(typeof(TValueObject), x,y,z);

    public static TValueObject Create(Vector3 vector3) => 
        Create(vector3.X, vector3.Y, vector3.Z);

    public static TValueObject Create(double x, double y, double z) => 
        (TValueObject)Activator.CreateInstance(typeof(TValueObject), 
            (TVector)Activator.CreateInstance(typeof(TVector), x),
            (TVector)Activator.CreateInstance(typeof(TVector), y),
            (TVector)Activator.CreateInstance(typeof(TVector), z)); 
    
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

    public override string ToString()
    {
        return $"{X}|{Y}|{Z}";
    }
}