using System;
using Blauhaus.Common.ValueObjects._Base;

namespace Blauhaus.Common.ValueObjects.BuildConfigs
{
    public class BuildConfig : BaseValueObject<IBuildConfig, string>, IBuildConfig
    {
        private BuildConfig(string value) : base(value)
        {
        }

        public static BuildConfig Debug => new BuildConfig(nameof(Debug));
        public static BuildConfig Release => new BuildConfig(nameof(Release));

        public static BuildConfig FromString(string value)
        {
            if (value.ToLowerInvariant().Equals("debug")) return Debug;
            if (value.ToLowerInvariant().Equals("release")) return Release;
            
            throw new ArgumentException($"BuildConfig string \'{value}\' not recognized. Only Debug and Release are currently supported");
        }
    }
}