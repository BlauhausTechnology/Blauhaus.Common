using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace Blauhaus.Common.Domain.CommandHandlers.Server
{
    public interface ICommandServerHandler<TPayload, TCommand, TUser> 
        where TCommand : notnull
        where TUser : notnull
    {
        Task<Result<TPayload>> HandleAsync(TCommand command, TUser authenticatedUser, CancellationToken token);
        
    }
}