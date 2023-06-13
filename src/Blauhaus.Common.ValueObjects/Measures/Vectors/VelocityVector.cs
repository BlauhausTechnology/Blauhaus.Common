using Blauhaus.Common.ValueObjects.Base;
using Blauhaus.Common.ValueObjects.Measures.Vectors.Base;

namespace Blauhaus.Common.ValueObjects.Measures.Vectors;

public class VelocityVector : BaseVectorValueObject<VelocityVector, Speed>
{
    public VelocityVector(Speed x, Speed y, Speed z) : base(x, y, z)
    {
    }

    public VelocityVector(double x, double y, double z) : base(x, y, z)
    {
    }


    public static VelocityVector Relative(VelocityVector ownVelocity, VelocityVector targetVelocity)
    {
        double x = ownVelocity.X.Value - targetVelocity.X.Value;
        double y = ownVelocity.Y.Value - targetVelocity.Y.Value;
        double z = ownVelocity.Z.Value - targetVelocity.Z.Value;

        return new VelocityVector(new Speed(x), new Speed(y), new Speed(z));
    }
}