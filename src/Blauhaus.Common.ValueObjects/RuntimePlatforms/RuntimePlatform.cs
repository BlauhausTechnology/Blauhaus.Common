using System;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.RuntimePlatforms
{
    public class RuntimePlatform : BaseValueObject<IRuntimePlatform, string>, IRuntimePlatform
    {

        private RuntimePlatform() { }

        private RuntimePlatform(string value) : base(value)
        {
        }

        public static RuntimePlatform Unknown => new RuntimePlatform(nameof(Unknown));
        public static RuntimePlatform Android => new RuntimePlatform(nameof(Android));
        public static RuntimePlatform iOS => new RuntimePlatform(nameof(iOS));
        public static RuntimePlatform UWP => new RuntimePlatform(nameof(UWP));
        public static RuntimePlatform DotNetCore => new RuntimePlatform(nameof(DotNetCore));

        public static RuntimePlatform FromString(string value)
        {
            if (value.ToLowerInvariant().Equals("android")) return Android;
            if (value.ToLowerInvariant().Equals("uwp")) return UWP;
            if (value.ToLowerInvariant().Equals("ios")) return iOS;
            if (value.ToLowerInvariant().Equals("dotnetcore")) return DotNetCore;

            throw new ArgumentException($"Platform string \'{value}\' not recognized. Only Android, iOS, UWP and DotNetCore are currently supported");
        }
    }
}