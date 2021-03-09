using Blauhaus.Common.Abstractions;

namespace Blauhaus.Common.TestHelpers.MockBuilders
{
    public class AsyncIdPublisherMockBuilder<TMock, T, TId> : BaseAsyncIdPublisherMockBuilder<AsyncIdPublisherMockBuilder<TMock, T, TId>, TMock, T, TId>
        where TMock : class, IAsyncIdPublisher<T, TId>
    {
    }
}