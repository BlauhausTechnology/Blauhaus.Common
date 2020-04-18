using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace Blauhaus.Common.Domain.CommandHandlers
{
    public interface IAuthenticatedCommandHandler<TPayload, in TCommand, in TUser>
    {
        Task<Result<TPayload>> HandleAsync(TCommand command, TUser authenticatedUser, CancellationToken token);
        
    }
}