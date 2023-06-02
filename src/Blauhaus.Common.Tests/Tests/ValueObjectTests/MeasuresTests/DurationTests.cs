using System;
using Blauhaus.Common.ValueObjects.Measures;
using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.ValueObjectTests.MeasuresTests;

public class DurationTests
{
    [Test]
    public void SHOULD_convert_a_minute_from_ticks_correctly()
    {
        //Act
        var timeSpan = TimeSpan.FromMinutes(1);
        var sut = new Duration(timeSpan.Ticks);

        //Assert
        Assert.That(sut.Nanoseconds, Is.EqualTo(timeSpan.TotalNanoseconds));
        Assert.That(sut.Ticks, Is.EqualTo(timeSpan.Ticks));
        Assert.That(sut.Microseconds, Is.EqualTo(timeSpan.TotalMicroseconds));
        Assert.That(sut.Milliseconds, Is.EqualTo(timeSpan.TotalMilliseconds));
        Assert.That(sut.Seconds, Is.EqualTo(timeSpan.TotalSeconds));
        Assert.That(sut.Minutes, Is.EqualTo(timeSpan.TotalMinutes));
        Assert.That(sut.Hours, Is.EqualTo(timeSpan.TotalHours));
        Assert.That(sut.Days, Is.EqualTo(timeSpan.TotalDays));
    }

    [Test]
    public void SHOULD_convert_weird_time_from_ticks_correctly()
    {
        //Act
        var timeSpan = new TimeSpan(1, 2, 3, 4, 5, 6);
        var sut = new Duration(timeSpan.Ticks);

        //Assert
        Assert.That(sut.Nanoseconds, Is.EqualTo(timeSpan.TotalNanoseconds));
        Assert.That(sut.Ticks, Is.EqualTo(timeSpan.Ticks));
        Assert.That(sut.Microseconds, Is.EqualTo(timeSpan.TotalMicroseconds));
        Assert.That(sut.Milliseconds, Is.EqualTo(timeSpan.TotalMilliseconds));
        Assert.That(sut.Seconds, Is.EqualTo(timeSpan.TotalSeconds));
        Assert.That(sut.Minutes, Is.EqualTo(timeSpan.TotalMinutes));
        Assert.That(sut.Hours, Is.EqualTo(timeSpan.TotalHours));
        Assert.That(sut.Days, Is.EqualTo(timeSpan.TotalDays));
    }

    [Test]
    public void SHOULD_convert_timespans()
    {
        //Arrange
        var timeSpan = new TimeSpan(1, 2, 3, 4, 5, 6);

        //Act
        var duration = Duration.FromTimespan(timeSpan);
        var result = duration.ToTimeSpan;

        //Assert
        Assert.That(timeSpan, Is.EqualTo(result));
    }

    [Test]
    public void SHOULD_convert_to_string()
    {
        Assert.That(Duration.FromTimespan(TimeSpan.FromDays(2.1)).ToString(), Is.EqualTo("2.1 days"));
        Assert.That(Duration.FromTimespan(TimeSpan.FromHours(2.1)).ToString(), Is.EqualTo("2.1 hours"));
        Assert.That(Duration.FromTimespan(TimeSpan.FromMinutes(2.1)).ToString(), Is.EqualTo("2.1 minutes"));
        Assert.That(Duration.FromTimespan(TimeSpan.FromSeconds(2.1)).ToString(), Is.EqualTo("2.1 seconds"));
        Assert.That(Duration.FromTimespan(TimeSpan.FromMilliseconds(2.1)).ToString(), Is.EqualTo("2.1 milliseconds"));
        Assert.That(Duration.FromTimespan(TimeSpan.FromMicroseconds(2.1)).ToString(), Is.EqualTo("2.1 microseconds"));
        Assert.That(Duration.FromTimespan(TimeSpan.FromTicks(2)).ToString(), Is.EqualTo("200 nanoseconds"));

    }

    [Test]
    public void SHOULD_create()
    {
        Assert.That(Duration.FromDays(2.1).Ticks, Is.EqualTo(TimeSpan.FromDays(2.1).Ticks));
        Assert.That(Duration.FromHours(2.1).Ticks, Is.EqualTo(TimeSpan.FromHours(2.1).Ticks));
        Assert.That(Duration.FromMinutes(2.1).Ticks, Is.EqualTo(TimeSpan.FromMinutes(2.1).Ticks));
        Assert.That(Duration.FromSeconds(2.1).Ticks, Is.EqualTo(TimeSpan.FromSeconds(2.1).Ticks));
        Assert.That(Duration.FromMilliseconds(2.1).Ticks, Is.EqualTo(TimeSpan.FromMilliseconds(2.1).Ticks));
        Assert.That(Duration.FromMicroseconds(2.1).Ticks, Is.EqualTo(TimeSpan.FromMicroseconds(2.1).Ticks));
        Assert.That(Duration.FromNanoseconds(200).Ticks, Is.EqualTo(TimeSpan.FromTicks(2).Ticks));
        Assert.That(Duration.FromTicks(200).Ticks, Is.EqualTo(TimeSpan.FromTicks(200).Ticks));

    }




}