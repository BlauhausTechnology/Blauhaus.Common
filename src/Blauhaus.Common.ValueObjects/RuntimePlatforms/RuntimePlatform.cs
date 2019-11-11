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
    }
}