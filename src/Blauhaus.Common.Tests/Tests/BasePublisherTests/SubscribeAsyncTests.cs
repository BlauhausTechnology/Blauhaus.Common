using System.Collections.Generic;
using System.Threading.Tasks;
using Blauhaus.Common.Tests.Tests.BasePublisherTests.Sut;
using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.BasePublisherTests
{
    public class SubscribeAsyncTests
    {
        public class DefinedOutput : SubscribeAsyncTests
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

    public class AnyOutput : SubscribeAsyncTests
    {
         [Test]
        public async Task WHEN_no_filter_is_given_SHOULD_always_update_subscribers()
        {
            //Arrange
            var sut = new TestBasePublisher();
            var updates = new List<int>();
            await sut.SubscribeAsync<int>(obj =>
            {
                updates.Add(obj);
                return Task.CompletedTask;
            });

            //Act
            await sut.UpdateAsync(2);
            await sut.UpdateAsync(5);

            //Assert
            Assert.That(updates.Count, Is.EqualTo(2));
            Assert.That(updates[0], Is.EqualTo(2));
            Assert.That(updates[1], Is.EqualTo(5));
        }

        [Test]
        public async Task WHEN_token_is_disposed_SHOULD_not_update()
        {
            //Arrange
            var sut = new TestBasePublisher();
            var updates = new List<int>();
            var token = await sut.SubscribeAsync<int>(obj =>
            {
                updates.Add(obj);
                return Task.CompletedTask;
            });

            //Act
            await sut.UpdateAsync(2);
            token.Dispose();
            await sut.UpdateAsync(5);

            //Assert
            Assert.That(updates.Count, Is.EqualTo(1));
            Assert.That(updates[0], Is.EqualTo(2));
        }


        [Test]
        public async Task WHEN_filter_is_given_SHOULD_only_update_subscribers_with_matching_subscription()
        {
            //Arrange
            var sut = new TestBasePublisher();
            var updates = new List<int>();
            await sut.SubscribeAsync<int>(obj =>
            {
                updates.Add(obj);
                return Task.CompletedTask;
            }, o => o > 2);

            //Act
            await sut.UpdateAsync(2);
            await sut.UpdateAsync(5);

            //Assert
            Assert.That(updates.Count, Is.EqualTo(1));
            Assert.That(updates[0], Is.EqualTo(5));
        }

    }
    
    
}