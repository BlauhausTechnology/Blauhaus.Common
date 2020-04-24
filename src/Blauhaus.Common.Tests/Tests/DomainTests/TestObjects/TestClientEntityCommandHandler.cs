using Blauhaus.Analytics.Abstractions.Service;
using Blauhaus.Common.Domain.CommandHandlers;
using Blauhaus.Common.Domain.CommandHandlers.Client;
using Blauhaus.Common.Domain.Repositories;

namespace Blauhaus.Common.Tests.Tests.DomainTests.TestObjects
{
    public class TestClientEntityCommandHandler : EntityCommandClientHandler<TestModel, TestModelDto, TestCommandDto, TestCommand>
    {
        public TestClientEntityCommandHandler(
            IAnalyticsService analyticsService, 
            ICommandConverter<TestCommandDto, TestCommand> converter, 
            ICommandHandler<TestModelDto, TestCommandDto> dtoCommandHandler, 
            IClientRepository<TestModel, TestModelDto> repository) 
                : base(analyticsService, converter, dtoCommandHandler, repository)
        {
        }
    }
}