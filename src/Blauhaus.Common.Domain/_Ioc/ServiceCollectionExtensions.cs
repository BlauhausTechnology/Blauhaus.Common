using Blauhaus.Common.Domain.CommandHandlers;
using Blauhaus.Common.Domain.CommandHandlers.Client;
using Blauhaus.Common.Domain.CommandHandlers.Server;
using Blauhaus.Common.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.Common.Domain._Ioc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommandServerHandler<TPayload, TCommand, TUser, TCommandHandler>(this IServiceCollection services) 
            where TCommandHandler : class, ICommandServerHandler<TPayload, TCommand, TUser>
        {
            services.AddScoped<ICommandServerHandler<TPayload, TCommand, TUser>, TCommandHandler>();
            return services;
        }

        public static IServiceCollection AddClientEntityCommandHandler<TModel, TModelDto, TCommandDto, TCommand, TCommandConverter, TDtoCommandHandler>(this IServiceCollection services) 
            where TModel : class, IClientEntity 
            where TCommandConverter : class, ICommandConverter<TCommandDto, TCommand>
            where TDtoCommandHandler : class, ICommandHandler<TModelDto, TCommandDto>
        {
            services.AddTransient<ICommandClientHandler<TModel, TCommand>, ClientEntityCommandHandler<TModel, TModelDto, TCommandDto, TCommand>>();
            services.AddTransient<ICommandConverter<TCommandDto, TCommand>, TCommandConverter>();
            services.AddTransient<ICommandHandler<TModelDto, TCommandDto>, TDtoCommandHandler>();
            return services;
        }
    }
}