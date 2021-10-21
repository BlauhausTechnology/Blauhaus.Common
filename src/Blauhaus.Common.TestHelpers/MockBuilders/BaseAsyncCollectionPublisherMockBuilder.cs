using System.Collections.Generic;
using System;
using Blauhaus.Common.Abstractions;
using Moq;

namespace Blauhaus.Common.TestHelpers.MockBuilders
{

    public abstract class BaseAsyncCollectionPublisherMockBuilder<TBuilder, TMock, T> : BaseAsyncPublisherMockBuilder<TBuilder, TMock, IReadOnlyList<T>>
        where TBuilder : BaseAsyncCollectionPublisherMockBuilder<TBuilder, TMock, T>
        where TMock : class, IAsyncCollectionPublisher<T>
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