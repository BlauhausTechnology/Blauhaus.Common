namespace Blauhaus.Common.Domain.CommandHandlers.Client
{
    public interface ICommandConverter<TCommandDto, TCommand>
    {
        TCommandDto Convert(TCommand command);
    }
}