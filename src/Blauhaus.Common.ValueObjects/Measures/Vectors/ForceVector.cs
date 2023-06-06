using Blauhaus.Common.ValueObjects.Base;
using Blauhaus.Common.ValueObjects.Measures.Vectors.Base;

namespace Blauhaus.Common.ValueObjects.Measures.Vectors;

public class ForceVector : BaseVectorValueObject<ForceVector, Force>
{
    public ForceVector(Force x, Force y, Force z) : base(x, y, z)
    {
    }
}