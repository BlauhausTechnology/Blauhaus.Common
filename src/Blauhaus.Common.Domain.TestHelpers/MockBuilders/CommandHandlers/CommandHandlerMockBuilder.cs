using Blauhaus.Common.Domain.CommandHandlers;
using Blauhaus.TestHelpers.MockBuilders;

namespace Blauhaus.Common.Domain.TestHelpers.MockBuilders.CommandHandlers
{
    public class CommandHandlerMockBuilder<TPayload, TCommand> : BaseCommandHandlerMockBuilder<CommandHandlerMockBuilder<TPayload, TCommand>, 
        ICommandHandler<TPayload, TCommand>, TPayload, TCommand>
    {
        
    }
}
