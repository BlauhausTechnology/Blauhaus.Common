using System;
using Blauhaus.Common.ValueObjects.Measures.MineGame.Common.Abstractions.Values.Measures;

namespace Blauhaus.Common.ValueObjects.Measures
{
    public class Latitude : Angle
    {
        public Latitude(double degrees) : base(degrees)
        {
            if (degrees is < -90 or > 90)
            {
                throw new ArgumentException("Latitude must be between -90 and 90 degrees");
            }
        }

        public static Latitude Equator = (Latitude) FromDegrees(0);
    }
}