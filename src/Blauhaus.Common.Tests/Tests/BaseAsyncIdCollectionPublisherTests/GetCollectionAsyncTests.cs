using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blauhaus.Common.Tests.Tests.BaseAsyncIdCollectionPublisherTests.Sut;
using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.BaseAsyncIdCollectionPublisherTests
{
    public class GetCollectionAsyncTests 
    { 
        [Test]
        public async Task SHOULD_return_whatever_ids_the_implemtation_returns()
        {
            //Arrange
            var mockPublisher = new HasIdPublisherMockBuilder();
            var sut = new TestAsyncIdPublisher(mockPublisher.Object);
            var idToReturn = Guid.NewGuid();
            sut.ItemsToLoad = new List<Guid> { idToReturn };

            //Act
            var result = await sut.GetCollectionAsync();

            //Assert
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result.Contains(idToReturn));
        }
    }
}