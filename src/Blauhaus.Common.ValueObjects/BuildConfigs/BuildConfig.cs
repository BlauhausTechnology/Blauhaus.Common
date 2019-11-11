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
    }
}