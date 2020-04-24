namespace Blauhaus.Common.Domain.CommandHandlers.Client
{
    public interface ICommandClientHandler<TPayload, TCommand> : ICommandHandler<TPayload, TCommand>
        where TCommand : notnull
    {
        
    }
}