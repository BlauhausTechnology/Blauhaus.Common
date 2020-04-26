using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace Blauhaus.Common.Domain.CommandHandlers
{
    public interface ICommandHandler<TPayload, TCommand> 
        where TCommand : notnull
    {
        Task<Result<TPayload>> HandleAsync(TCommand command, CancellationToken token);
    }

    public interface IVoidCommandHandler<TCommand> 
        where TCommand : notnull
    {
        Task<Result> HandleAsync(TCommand command, CancellationToken token);
    }
}