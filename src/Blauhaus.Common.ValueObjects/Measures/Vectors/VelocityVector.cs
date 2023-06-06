using Blauhaus.Common.ValueObjects.Base;
using Blauhaus.Common.ValueObjects.Measures.Vectors.Base;

namespace Blauhaus.Common.ValueObjects.Measures.Vectors;

public class VelocityVector : BaseVectorValueObject<VelocityVector, Speed>
{
    public VelocityVector(Speed x, Speed y, Speed z) : base(x, y, z)
    {
    }

}