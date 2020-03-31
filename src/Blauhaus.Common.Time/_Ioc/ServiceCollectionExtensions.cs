using Blauhaus.Common.Time.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.Common.Time._Ioc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterTimeService(this IServiceCollection iocService)
        {
            iocService.AddScoped<ITimeService, TimeService>();
            return iocService;
        }
    }
}