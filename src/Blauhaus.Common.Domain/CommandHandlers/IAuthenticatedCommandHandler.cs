using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace Blauhaus.Common.Domain.CommandHandlers
{
    public interface IAuthenticatedCommandHandler<TPayload, TCommand, TUser> //don't make contravariant else they want to be nullable
    {
        Task<Result<TPayload>> HandleAsync(TCommand command, TUser authenticatedUser, CancellationToken token);
        
    }
}