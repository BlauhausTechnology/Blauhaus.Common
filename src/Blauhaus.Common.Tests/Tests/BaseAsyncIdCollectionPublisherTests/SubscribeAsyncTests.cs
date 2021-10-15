using Blauhaus.Common.Tests.Tests.BaseAsyncIdCollectionPublisherTests.Sut;
using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Blauhaus.Common.TestHelpers.Extensions;

namespace Blauhaus.Common.Tests.Tests.BaseAsyncIdCollectionPublisherTests
{
    public class SubscribeAsyncTests
    {
        [Test]
        public async Task SHOULD_update_subscribers_with_all_ids_WHEN_publisher_publishes()
        {
            //Arrange 
            var mockPublisher = new HasIdPublisherMockBuilder();
            var sut = new TestAsyncIdPublisher(mockPublisher.Object)
            {
                ItemsToLoad = new List<Guid>()
            };
            
            var idToReturn = Guid.NewGuid();
            using var updates = await sut.SubscribeToUpdatesAsync();

            //Act
            sut.ItemsToLoad = new List<Guid> { idToReturn };
            await mockPublisher.PublishMockSubscriptionAsync(new TestHasId());

            //Assert 
            Assert.That(updates[0].Count, Is.EqualTo(1));
            Assert.That(updates[0].Contains(idToReturn)); 
        }
         
    }
}