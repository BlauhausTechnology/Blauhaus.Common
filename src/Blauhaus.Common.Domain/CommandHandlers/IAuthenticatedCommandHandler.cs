using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace Blauhaus.Common.Domain.CommandHandlers
{
    public interface IAuthenticatedCommandHandler<in TCommand, TPayload>
    {
        Task<Result<TPayload>> HandleAsync(TCommand command, IAuthenticatedUser user, CancellationToken token);
        
    }
}