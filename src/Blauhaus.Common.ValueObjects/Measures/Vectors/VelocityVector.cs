using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures.Vectors;

public class VelocityVector : BaseVectorValueObject<VelocityVector, Speed>
{
    public VelocityVector(Speed x, Speed y, Speed z) : base(x, y, z)
    {
    }
}