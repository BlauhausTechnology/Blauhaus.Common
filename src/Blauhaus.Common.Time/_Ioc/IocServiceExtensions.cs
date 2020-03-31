using Blauhaus.Common.Time.Service;
using Blauhaus.Ioc.Abstractions;

namespace Blauhaus.Common.Time._Ioc
{
    public static class IocServiceExtensions
    {
        public static IIocService RegisterTimeService(this IIocService iocService)
        {
            iocService.RegisterImplementation<ITimeService, TimeService>();
            return iocService;
        }
    }
}