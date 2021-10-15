using System;
using Blauhaus.Common.Abstractions;

namespace Blauhaus.Common.Tests.Tests.BaseAsyncIdCollectionPublisherTests.Sut
{
    public class TestHasId : IHasId<Guid>
    {
        public Guid Id { get; set; }
    }
}