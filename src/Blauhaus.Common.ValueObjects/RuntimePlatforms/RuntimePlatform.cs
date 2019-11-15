using System;
using Blauhaus.Common.ValueObjects._Base;

namespace Blauhaus.Common.ValueObjects.RuntimePlatforms
{
    public class RuntimePlatform : BaseValueObject<IRuntimePlatform, string>, IRuntimePlatform
    {
        private RuntimePlatform(string value) : base(value)
        {
        }

        public static RuntimePlatform Android => new RuntimePlatform(nameof(Android));
        public static RuntimePlatform iOS => new RuntimePlatform(nameof(iOS));
        public static RuntimePlatform UWP => new RuntimePlatform(nameof(UWP));

        public static RuntimePlatform FromString(string value)
        {
            if (value.ToLowerInvariant().Equals("android")) return Android;
            if (value.ToLowerInvariant().Equals("uwp")) return UWP;
            if (value.ToLowerInvariant().Equals("ios")) return iOS;

            throw new ArgumentException($"Platform string \'{value}\' not recognized. ");
        }
    }
}