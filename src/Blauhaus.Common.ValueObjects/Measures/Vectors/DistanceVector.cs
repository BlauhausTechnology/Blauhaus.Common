using System;
using System.Numerics;
using Blauhaus.Common.ValueObjects.Measures.Vectors.Base;

namespace Blauhaus.Common.ValueObjects.Measures.Vectors;

public class DistanceVector : BaseVectorValueObject<DistanceVector, Distance>
{
    public DistanceVector(Distance x, Distance y, Distance z) : base(x, y, z)
    {
    }

    public DistanceVector(double x, double y, double z) : base(x, y, z)
    {
    }

    public Distance Length => Distance.FromMetres(
        Math.Sqrt(Math.Pow(X.Metres, 2) + Math.Pow(Y.Metres, 2) + Math.Pow(Z.Metres, 2)));

    public static DistanceVector FromMetres(double x, double y, double z) 
        => new(Distance.FromMetres(x), Distance.FromMetres(y), Distance.FromMetres(z));

    public static DistanceVector FromPositionVectorsMetres(Vector3 origin, Vector3 target)
    {
        float x = target.X - origin.X;
        float y = target.Y - origin.Y;
        float z = target.Z - origin.Z;
        return FromMetres(x, y, z);
    }
}