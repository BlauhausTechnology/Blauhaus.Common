using Blauhaus.Common.Domain.CommandHandlers;
using Blauhaus.Common.Domain.CommandHandlers.Client;
using Blauhaus.Common.Domain.Entities;
using Blauhaus.Ioc.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.Common.Domain._Ioc
{
    public static class IocServiceExtensions
    {
        public static IIocService AddCommandServerHandler<TPayload, TCommand, TUser, TCommandHandler>(this IIocService iocService) 
            where TCommandHandler : class, IAuthenticatedCommandHandler<TPayload, TCommand, TUser>
        {
            iocService.RegisterImplementation<IAuthenticatedCommandHandler<TPayload, TCommand, TUser>, TCommandHandler>();
            return iocService;
        }

        public static IIocService AddClientEntityCommandHandler<TModel, TModelDto, TCommandDto, TCommand, TCommandConverter, TDtoCommandHandler>(this IIocService iocService) 
            where TModel : class, IClientEntity 
            where TCommandConverter : class, ICommandConverter<TCommandDto, TCommand>
            where TDtoCommandHandler : class, ICommandHandler<TModelDto, TCommandDto>
        {
            iocService.RegisterImplementation<ICommandHandler<TModel, TCommand>, ClientEntityCommandHandler<TModel, TModelDto, TCommandDto, TCommand>>();
            iocService.RegisterImplementation<ICommandConverter<TCommandDto, TCommand>, TCommandConverter>();
            iocService.RegisterImplementation<ICommandHandler<TModelDto, TCommandDto>, TDtoCommandHandler>();
            return iocService;
        }
    }
}