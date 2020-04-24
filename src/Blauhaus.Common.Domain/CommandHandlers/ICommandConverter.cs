namespace Blauhaus.Common.Domain.CommandHandlers
{
    public interface ICommandConverter<TCommandDto, TCommand>
    {
        TCommandDto Convert(TCommand command);
    }
}