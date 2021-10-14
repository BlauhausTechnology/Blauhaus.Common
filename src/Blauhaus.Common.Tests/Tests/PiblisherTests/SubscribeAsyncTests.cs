using System.Collections.Generic;
using System.Threading.Tasks;
using Blauhaus.Common.Tests.Tests.PiblisherTests.Sut;
using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.PiblisherTests
{
    public class SubscribeAsyncTests
    {
        [Test]
        public async Task WHEN_no_filter_is_given_SHOULD_always_update_subscribers()
        {
            //Arrange
            var sut = new TestBasePublisher();
            var updates = new List<TestObject>();
            await sut.SubscribeAsync((obj) =>
            {
                updates.Add(obj);
                return Task.CompletedTask;
            });

            //Act
            await sut.UpdateAsync(new TestObject{ Id = 2 });
            await sut.UpdateAsync(new TestObject{ Id = 5 });

            //Assert
            Assert.That(updates.Count, Is.EqualTo(2));
            Assert.That(updates[0].Id, Is.EqualTo(2));
            Assert.That(updates[1].Id, Is.EqualTo(5));
        }

        [Test]
        public async Task WHEN_token_is_disposed_SHOULD_not_update()
        {
            //Arrange
            var sut = new TestBasePublisher();
            var updates = new List<TestObject>();
            var token = await sut.SubscribeAsync(obj =>
            {
                updates.Add(obj);
                return Task.CompletedTask;
            });

            //Act
            await sut.UpdateAsync(new TestObject{ Id = 2 });
            token.Dispose();
            await sut.UpdateAsync(new TestObject{ Id = 5 });

            //Assert
            Assert.That(updates.Count, Is.EqualTo(1));
            Assert.That(updates[0].Id, Is.EqualTo(2));
        }


        [Test]
        public async Task WHEN_filter_is_given_SHOULD_only_update_subscribers_with_matching_subscription()
        {
            //Arrange
            var sut = new TestBasePublisher();
            var updates = new List<TestObject>();
            await sut.SubscribeAsync(obj =>
            {
                updates.Add(obj);
                return Task.CompletedTask;
            }, o => o.Id > 2);

            //Act
            await sut.UpdateAsync(new TestObject{ Id = 2 });
            await sut.UpdateAsync(new TestObject{ Id = 5 });

            //Assert
            Assert.That(updates.Count, Is.EqualTo(1));
            Assert.That(updates[0].Id, Is.EqualTo(5));
        }

    }
}