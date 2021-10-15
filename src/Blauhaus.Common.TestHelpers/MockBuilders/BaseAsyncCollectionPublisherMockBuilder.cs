using System.Collections.Generic;
using System;
using Blauhaus.Common.Abstractions;
using Moq;

namespace Blauhaus.Common.TestHelpers.MockBuilders
{

    public abstract class BaseAsyncCollectionPublisherMockBuilder<TBuilder, TMock, T, TId> : BaseAsyncPublisherMockBuilder<TBuilder, TMock, IReadOnlyList<T>>
        where TBuilder : BaseAsyncCollectionPublisherMockBuilder<TBuilder, TMock, T, TId>
        where TMock : class, IAsyncCollectionPublisher<T, TId>
    {
        protected BaseAsyncCollectionPublisherMockBuilder()
        {
            Where_LoadCollectionAsync_returns(Array.Empty<T>());
        }

        public TBuilder Where_LoadCollectionAsync_returns(IReadOnlyList<T> collection)
        {
            Mock.Setup(x => x.GetCollectionAsync()).ReturnsAsync(collection);
            return (TBuilder)this;
        }
    }
}