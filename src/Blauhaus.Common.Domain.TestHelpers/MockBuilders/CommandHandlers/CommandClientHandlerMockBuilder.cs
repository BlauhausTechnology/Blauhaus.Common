using Blauhaus.Common.Domain.CommandHandlers;
using Blauhaus.Common.Domain.CommandHandlers.Client;
using Blauhaus.Common.Domain.TestHelpers.MockBuilders.CommandHandlers._Base;
using Blauhaus.TestHelpers.MockBuilders;

namespace Blauhaus.Common.Domain.TestHelpers.MockBuilders.CommandHandlers
{
    public class CommandClientHandlerMockBuilder<TBuilder, TMock, TPayload, TCommand> : BaseCommandHandlerMockBuilder<TBuilder, TMock, TPayload, TCommand> 
        where TBuilder : BaseMockBuilder<TBuilder, TMock> 
        where TMock : class, ICommandClientHandler<TPayload, TCommand>
    {
        
    }
}