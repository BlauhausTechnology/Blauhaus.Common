using Blauhaus.Common.Abstractions;
using Blauhaus.Common.TestHelpers.MockBuilders;
using Blauhaus.TestHelpers;
using Blauhaus.TestHelpers.MockBuilders;

namespace Blauhaus.Common.TestHelpers.Extensions
{
    public static class MockContainerExtensions
    {
        public static AsyncPublisherMockBuilder<TMock, T> AddMockAsyncPublisher<TMock, T>(this MockContainer mocks) 
            where TMock : class, IAsyncPublisher<T>
        {
            var mock = new AsyncPublisherMockBuilder<TMock, T>();
            mocks.AddMock<AsyncPublisherMockBuilder<TMock, T>, TMock>();
            return mock;
        }
    }
}