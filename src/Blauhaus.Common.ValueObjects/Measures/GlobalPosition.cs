using System;
using System.Globalization;
using System.Numerics;
using Blauhaus.Common.ValueObjects.Base;
using Blauhaus.Common.ValueObjects.Measures.Vectors;

namespace Blauhaus.Common.ValueObjects.Measures
{
    public class GlobalPosition : BaseValueObject<GlobalPosition>
    {
        public GlobalPosition(Distance globeRadius, Angle latitude, Angle longitude, Distance? altitude = null)
        {

            if (latitude.Degrees is < -90 or > 90)
            {
                throw  new InvalidOperationException("Latitude must be between -90 and 90 degrees");
            }

            if (longitude.Degrees is < -180 or > 180)
            {
                throw new InvalidOperationException("Longitude must be between -180 and 180 degrees");
            }

            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude == null ? Distance.Zero : altitude;
            GlobeRadius = globeRadius;
        }

        public Angle Latitude { get; }
        public Angle Longitude { get; }
        public Distance Altitude { get; }
        public Distance GlobeRadius { get; }

        public static GlobalPosition NullIsland = Create(0, 0, 1000);

        public static GlobalPosition Create(double latitudeDegrees, double longitudeDegrees, double globeRadiusKm = 1, double altitudeM = 0)
            => new(new Distance(globeRadiusKm), Angle.FromDegrees(latitudeDegrees), Angle.FromDegrees(longitudeDegrees),
                 new Distance(altitudeM / 1000));

        public string Serialize()
        {
            return $"{Latitude.Value.ToString(CultureInfo.InvariantCulture)}|" +
                   $"{Longitude.Value.ToString(CultureInfo.InvariantCulture)}|" +
                   $"{Altitude.Value.ToString(CultureInfo.InvariantCulture)}|" +
                   $"{GlobeRadius.Value.ToString(CultureInfo.InvariantCulture)}";
        }

        public static GlobalPosition Deserialize(string serialized)
        {
            var elements = serialized.Split('|');
            if (elements.Length != 4)
            {
                throw new InvalidOperationException($"{serialized} is not a valid serialization of GlobalPosition because it has {elements.Length} elements instead of 4");
            }

            if (!double.TryParse(elements[0], out var latitude))
                throw new InvalidOperationException($"{serialized} is not a valid serialization of GlobalPosition because {elements[0]} is not a valid Latitude");
            if (!double.TryParse(elements[1], out var longitude))
                throw new InvalidOperationException($"{serialized} is not a valid serialization of GlobalPosition because {elements[1]} is not a valid Longitude");
            if (!double.TryParse(elements[2], out var altitude))
                throw new InvalidOperationException($"{serialized} is not a valid serialization of GlobalPosition because {elements[2]} is not a valid Distance");
            if (!double.TryParse(elements[3], out var globalRadius))
                throw new InvalidOperationException($"{serialized} is not a valid serialization of GlobalPosition because {elements[3]} is not a valid Distance");

            return Create(latitude, longitude, globalRadius, altitude*1000);

        }

        public double DistanceFrom(GlobalPosition other)
        {
            var latitudeDifferenceFactor = (Latitude.Radians - other.Latitude.Radians)/2;
            var longitudeDifferenceFactor = (Longitude.Radians - other.Longitude.Radians)/2;

            var haversine = 
                Math.Pow(Math.Sin(latitudeDifferenceFactor), 2) + 
                Math.Pow(Math.Sin(longitudeDifferenceFactor), 2) 
                * Math.Cos(Latitude.Radians) * Math.Cos(other.Latitude.Radians);

            return Math.Asin(Math.Sqrt(haversine)) * 2 * GlobeRadius.Kilometres;
        }
        
        public Vector3 ToPositionVector()
        {
            var x = (float)(GlobeRadius.Kilometres * Math.Cos(Latitude.Radians) * Math.Cos(Longitude.Radians));
            var y = (float)(GlobeRadius.Kilometres * Math.Cos(Latitude.Radians) * Math.Sin(Longitude.Radians));
            var z = (float)(GlobeRadius.Kilometres * Math.Sin(Latitude.Radians));
            
            return new Vector3(x, y, z);
        }

        public DistanceVector ToDistanceVector()
        {
            double x = (GlobeRadius.Metres * Math.Cos(Latitude.Radians) * Math.Cos(Longitude.Radians));
            double y = (GlobeRadius.Metres * Math.Cos(Latitude.Radians) * Math.Sin(Longitude.Radians));
            double z = (GlobeRadius.Metres * Math.Sin(Latitude.Radians));
            
            return DistanceVector.FromMetres(x, y, z);
        }
        
        public static GlobalPosition FromPositionVector(Vector3 positionVector, float radius = 1)
        {
            var globeRadius = new Distance(radius);
            var latitude = Angle.FromRadians(Math.Asin(positionVector.Z / radius));
            var longitude = Angle.FromRadians(Math.Atan2(positionVector.Y, positionVector.X));
            var altitude = new Distance(positionVector.Length() - radius);
            
            return new GlobalPosition(globeRadius, latitude, longitude, altitude);
        }

        #region Equality & ToString


        protected override int GetHashCodeCore()
        {
            return Latitude.GetHashCode() ^ Longitude.GetHashCode() ^ Altitude.GetHashCode() ^ GlobeRadius.GetHashCode();
        }

        protected override bool EqualsCore(GlobalPosition other)
        {
            return GlobeRadius == other.GlobeRadius &&
                   Latitude == other.Latitude &&
                   Longitude == other.Longitude &&
                   Altitude == other.Altitude;
        }

        public override string ToString()
        {
            return $"Lat {Latitude} | Long {Longitude} | Altitude {Altitude}";
        }
        #endregion

    }
}