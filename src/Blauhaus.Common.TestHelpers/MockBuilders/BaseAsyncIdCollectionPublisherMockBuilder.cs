using Blauhaus.Common.Abstractions;

namespace Blauhaus.Common.TestHelpers.MockBuilders
{
    public abstract class BaseAsyncIdCollectionPublisherMockBuilder<TBuilder, TMock, TId> : BaseAsyncCollectionPublisherMockBuilder<TBuilder, TMock, TId, TId>
        where TBuilder : BaseAsyncIdCollectionPublisherMockBuilder<TBuilder, TMock, TId>
        where TMock : class, IAsyncIdCollectionPublisher<TId>
    {
 
    }

}