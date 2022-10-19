using System;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures
{
    public class Power : BaseNumericValueObject<Power>
    {
        public Power(decimal value) : base(value)
        {
        }

        public decimal Watts => Value;
        public decimal KiloWatts => Watts / 1000m;

        public static Power FromWatts(decimal watts)
        {
            return new Power(watts);
        }

        public static Power FromEnergy(Energy energy, TimeSpan elapsedTime)
        {
            var val = (energy.WattHours * 60 * 60) / Convert.ToDecimal(elapsedTime.TotalSeconds);
            return FromWatts(val);
        }

        public Energy ToEnergy(TimeSpan elapsedTime)
        {
            return new Energy(Watts * Convert.ToDecimal(elapsedTime.TotalHours));
        } 

        public Power Add(decimal otherWatts)
        {
            return new Power(Watts + otherWatts);
        }
 
    }
}