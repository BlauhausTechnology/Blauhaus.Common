using Blauhaus.Common.ValueObjects.Base;
using System;

namespace Blauhaus.Common.ValueObjects.Measures.Vectors;

public class AccelerationVector : BaseVectorValueObject<AccelerationVector, Acceleration>
{
    public AccelerationVector(Acceleration x, Acceleration y, Acceleration z) : base(x, y, z)
    {
    }


}