using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blauhaus.Common.Abstractions;
using Blauhaus.Common.Utils.Disposables;

namespace Blauhaus.Common.Tests.Tests.BaseAsyncIdCollectionPublisherTests.Sut
{
    public class TestAsyncIdPublisher : BaseAsyncIdCollectionPublisher<TestHasId, IAsyncPublisher<TestHasId>, Guid>
    {
        public TestAsyncIdPublisher(IAsyncPublisher<TestHasId> dtoCache) : base(dtoCache)
        {
        }

        protected override Task<IReadOnlyList<Guid>> LoadItemsAsync(Guid collectionId)
        {
            return Task.FromResult<IReadOnlyList<Guid>>(ItemsToLoad);
        }

        public List<Guid> ItemsToLoad { get; set; } = new();
    }
}