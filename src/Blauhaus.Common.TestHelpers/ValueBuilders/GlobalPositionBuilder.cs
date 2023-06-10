using Blauhaus.Common.ValueObjects.Measures;
using Blauhaus.TestHelpers.Builders.Base;

namespace Blauhaus.Common.TestHelpers.ValueBuilders;

public class GlobalPositionBuilder : BaseBuilder<GlobalPositionBuilder, GlobalPosition>
{
    public GlobalPositionBuilder()
    {
        _globeRadius = Distance.FromKilometres(1000);
        _altitude = Distance.FromKilometres(0);
        _latitude = Angle.FromDegrees(Random.Next(-80,80));
        _longitude = Angle.FromDegrees(Random.Next(-170,170));
    }
    protected override GlobalPosition Construct()
    {
        return new GlobalPosition(_globeRadius, _latitude, _longitude, _altitude);
    }

    private Distance _altitude;
    public GlobalPositionBuilder WithAltitude(Distance altitude)
    {
        _altitude = altitude;
        return this;
    }
    
    private Distance _globeRadius;

    public GlobalPositionBuilder WithGlobeRadius(Distance globeRadiues)
    {
        _globeRadius = globeRadiues;
        return this;
    }
    
    private Angle _latitude;
    public GlobalPositionBuilder WithLatitude(Angle latitude)
    {
        _latitude = latitude;
        return this;
    }
    public GlobalPositionBuilder WithLatitude(double latitude)
    {
        _latitude = Angle.FromDegrees(latitude);
        return this;
    }


    private Angle _longitude;
    public GlobalPositionBuilder WithLongitude(Angle longitude)
    {
        _longitude = longitude;
        return this;
    }
    public GlobalPositionBuilder WithLongitude(double longitude)
    {
        _longitude = Angle.FromDegrees(longitude);
        return this;
    }
}