using System;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.BuildConfigs
{
    public class BuildConfig : BaseValueObject<IBuildConfig, string>, IBuildConfig
    {
        
        private BuildConfig() { }

        private BuildConfig(string value) : base(value)
        {
        }

        public static BuildConfig Debug => new BuildConfig(nameof(Debug));
        public static BuildConfig Test => new BuildConfig(nameof(Test));
        public static BuildConfig Staging => new BuildConfig(nameof(Staging));
        public static BuildConfig Release => new BuildConfig(nameof(Release));

        public static BuildConfig FromString(string value)
        {
            if (value.ToLowerInvariant().Equals("debug")) return Debug;
            if (value.ToLowerInvariant().Equals("release")) return Release;
            if (value.ToLowerInvariant().Equals("test")) return Test;
            if (value.ToLowerInvariant().Equals("staging")) return Staging;
            
            throw new ArgumentException($"BuildConfig string \'{value}\' not recognized. Only Debug, Test, Staging and Release are currently supported");
        }
    }
}