using System;
using System.Text.Json.Serialization;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures;

public class Ratio : BaseDoubleValueObject<Ratio>
{
    [JsonConstructor]
    public Ratio(double value) : base(value) { }


    public double Decibels => 10 * Math.Log10(Value);


    public static Ratio FromValues(double numerator, double denominator)
    {
        return new Ratio(numerator / denominator);
    }

    public static Ratio FromDecibels(double decibels)
    {
        return new Ratio(Math.Pow(10, decibels / 10d));
    }
     
}