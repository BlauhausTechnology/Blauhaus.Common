﻿using System;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Measures
{
    public class Power : BaseDoubleValueObject<Power>
    {
        public Power(double value) : base(value)
        {
        }

        public double Watts => Value;
        public double KiloWatts => Watts / 1000d;

        public static Power FromWatts(double watts)
        {
            return new Power(watts);
        }

        public static Power FromEnergy(Energy energy, TimeSpan elapsedTime)
        {
            var val = (energy.WattHours * 60 * 60) / elapsedTime.TotalSeconds;
            return FromWatts(val);
        }

        public Energy ToEnergy(TimeSpan elapsedTime)
        {
            return new Energy(Watts * elapsedTime.TotalHours);
        } 

        public Power Add(double otherWatts)
        {
            return new Power(Watts + otherWatts);
        }

        public override string ToString()
        {
            if (Value < 1000)
            {
                return $"{Math.Round(Watts, 3)} W";
            }
            
            return $"{Math.Round(KiloWatts, 3)} KW";

        }
 
    }
}