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
        double x = targetVelocity.X.Value - ownVelocity.X.Value;
        double y = targetVelocity.Y.Value - ownVelocity.Y.Value;
        double z = targetVelocity.Z.Value - ownVelocity.Z.Value;

        return new VelocityVector(new Speed(x), new Speed(y), new Speed(z));
    }
}