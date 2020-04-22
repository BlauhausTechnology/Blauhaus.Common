using Blauhaus.Common.Domain.CommandHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.Common.Domain._Ioc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAuthenticatedCommandHandler<TPayload, TCommand, TUser, TCommandHandler>(this IServiceCollection services) 
            where TCommandHandler : class, IAuthenticatedCommandHandler<TPayload, TCommand, TUser>
        {
            services.AddScoped<IAuthenticatedCommandHandler<TPayload, TCommand, TUser>, TCommandHandler>();
            return services;
        }
    }
}