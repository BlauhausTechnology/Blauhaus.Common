using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.DeviceType
{
    public class DeviceType : BaseValueObject<IDeviceType, string>, IDeviceType
    {
        
        private DeviceType() { }

        protected DeviceType(string value) : base(value)
        {
        }

        
        public static DeviceType Unknown => new(nameof(Unknown));
        public static DeviceType Phone => new(nameof(Phone));
        public static DeviceType Tablet => new(nameof(Tablet));
        public static DeviceType PC => new(nameof(PC));
        public static DeviceType TV => new(nameof(TV));
        public static DeviceType Watch => new(nameof(Watch));
        public static DeviceType Server => new(nameof(Server));
    }
}