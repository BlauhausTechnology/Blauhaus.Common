using Blauhaus.Common.Domain.CommandHandlers;
using Blauhaus.Common.Domain.CommandHandlers.Client;

namespace Blauhaus.Common.Tests.Tests.DomainTests.TestObjects
{
    public class TestCommandConverter : ICommandConverter<TestCommandDto, TestCommand>
    {
        public TestCommandDto Convert(TestCommand command)
        {
            return new TestCommandDto
            {
                Name = command.Name
            };
        }
    }
}