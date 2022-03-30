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

        [Obsolete("Use Windows instead")]
        public static RuntimePlatform UWP => new(nameof(UWP));
        public static RuntimePlatform Unknown => new(nameof(Unknown));
        public static RuntimePlatform Android => new(nameof(Android));
        public static RuntimePlatform iOS => new(nameof(iOS));
        public static RuntimePlatform Windows => new(nameof(Windows));
        public static RuntimePlatform Mac => new(nameof(Mac));
        public static RuntimePlatform DotNetCore => new(nameof(DotNetCore));

        public static RuntimePlatform FromString(string value)
        {
            if (value.ToLowerInvariant().Equals("android")) return Android;
            if (value.ToLowerInvariant().Equals("uwp")) return UWP;
            if (value.ToLowerInvariant().Equals("ios")) return iOS;
            if (value.ToLowerInvariant().Equals("dotnetcore")) return DotNetCore;
            if (value.ToLowerInvariant().Equals("windows")) return Windows;
            if (value.ToLowerInvariant().Equals("mac")) return Mac;

            throw new ArgumentException($"Platform string \'{value}\' not recognized. Only Android, iOS, UWP and DotNetCore are currently supported");
        }
    }
}