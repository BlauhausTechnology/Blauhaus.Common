using Blauhaus.Common.Domain.CommandHandlers;
using Blauhaus.Common.Domain.CommandHandlers.Client;
using Blauhaus.Common.Domain.TestHelpers.MockBuilders.CommandHandlers._Base;
using Blauhaus.TestHelpers.MockBuilders;

namespace Blauhaus.Common.Domain.TestHelpers.MockBuilders.CommandHandlers
{
    public class CommandClientHandlerMockBuilder<TPayload, TCommand> : BaseCommandHandlerMockBuilder<CommandClientHandlerMockBuilder<TPayload, TCommand>, 
        ICommandClientHandler<TPayload, TCommand>, TPayload, TCommand> 
    {
        
    }
}