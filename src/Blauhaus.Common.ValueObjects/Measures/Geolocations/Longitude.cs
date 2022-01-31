//using System;
//using Blauhaus.Common.ValueObjects.Measures.MineGame.Common.Abstractions.Values.Measures;

//namespace Blauhaus.Common.ValueObjects.Measures.Geolocations
//{
//    public class Longitude : Angle
//    {
//        public Longitude(double degrees) : base(degrees)
//        {
//            if (degrees is < -180 or > 180)
//            {
//                throw new ArgumentException("Longitude must be between -90 and 90 degrees");
//            }
//        }
         
//        public static Longitude PrimeMeridian = (Longitude) FromDegrees(0);
//    }
//}