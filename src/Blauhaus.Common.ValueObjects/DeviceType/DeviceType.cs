using Blauhaus.Common.ValueObjects._Base;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;

namespace Blauhaus.Common.ValueObjects.DeviceType
{
    public class DeviceType : BaseValueObject<IDeviceType, string>, IDeviceType
    {
        protected DeviceType(string value) : base(value)
        {
        }

        
        public static DeviceType Unknown => new DeviceType(nameof(Unknown));
        public static DeviceType Phone => new DeviceType(nameof(Phone));
        public static DeviceType Tablet => new DeviceType(nameof(Tablet));
        public static DeviceType PC => new DeviceType(nameof(PC));
        public static DeviceType TV => new DeviceType(nameof(TV));
        public static DeviceType Watch => new DeviceType(nameof(Watch));
        public static DeviceType Server => new DeviceType(nameof(Server));
    }
}