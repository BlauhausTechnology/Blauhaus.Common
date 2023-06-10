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

    public Distance Distance => Distance.FromMetres(
        Math.Sqrt(Math.Pow(X.Metres, 2) + Math.Pow(Y.Metres, 2) + Math.Pow(Z.Metres, 2)));

    public static DistanceVector FromMetres(double x, double y, double z) 
        => new(Distance.FromMetres(x), Distance.FromMetres(y), Distance.FromMetres(z));

    public static DistanceVector FromDistanceVectors(DistanceVector source, DistanceVector target)
    {
        double x = target.X.Metres - source.X.Metres;
        double y = target.Y.Metres - source.Y.Metres;
        double z = target.Z.Metres - source.Z.Metres;
        return FromMetres(x, y, z);
    }

    public static DistanceVector FromGlobalPositions(GlobalPosition source, GlobalPosition target)
    {
        var sourceVector = source.ToDistanceVector();
        var targetVector = target.ToDistanceVector();
        return FromDistanceVectors(sourceVector, targetVector);
    }
}