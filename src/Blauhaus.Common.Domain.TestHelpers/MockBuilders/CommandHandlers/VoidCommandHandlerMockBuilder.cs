using Blauhaus.Common.Domain.CommandHandlers;
using Blauhaus.Common.Domain.TestHelpers.MockBuilders.CommandHandlers._Base;
using Blauhaus.TestHelpers.MockBuilders;

namespace Blauhaus.Common.Domain.TestHelpers.MockBuilders.CommandHandlers
{
    public class VoidCommandHandlerMockBuilder<TCommand> : BaseVoidCommandHandlerMockBuilder<VoidCommandHandlerMockBuilder<TCommand>, 
        IVoidCommandHandler<TCommand>, TCommand>
    {
        
    }
}
