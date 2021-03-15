using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blauhaus.Common.Abstractions;
using Blauhaus.TestHelpers.MockBuilders;
using Moq;

namespace Blauhaus.Common.TestHelpers.MockBuilders
{
    
     public abstract class BaseAsyncIdPublisherMockBuilder<TBuilder, TMock, T, TId> : BaseMockBuilder<TBuilder, TMock>
        where TBuilder : BaseAsyncIdPublisherMockBuilder<TBuilder, TMock, T, TId>
        where TMock : class, IAsyncIdPublisher<T, TId>

    {
        private readonly List<Func<T, Task>> _handlers = new List<Func<T, Task>>();

        protected BaseAsyncIdPublisherMockBuilder()
        {
            Mock.Setup(x => x.SubscribeAsync(It.IsAny<Func<T, Task>>(), It.IsAny<TId>()))
                .Callback((Func<T, Task> handler, long id) =>
                {
                    _handlers.Add(handler);
                });
            
        }
        public Mock<IDisposable> Where_SubscribeAsync_returns_token()
        {
            var mockToken = new Mock<IDisposable>();
            
            Mock.Setup(x => x.SubscribeAsync(It.IsAny<Func<T, Task>>(), It.IsAny<TId>()))
                .ReturnsAsync(mockToken.Object);
            
            return mockToken;
        }

        public Mock<IDisposable> Where_SubscribeAsync_publishes_immediately(T update)
        {
            var mockToken = new Mock<IDisposable>();

            Mock.Setup(x => x.SubscribeAsync(It.IsAny<Func<T, Task>>(), It.IsAny<TId>()))
                .Callback(async (Func<T, Task> handler, long id) =>
                {
                    await handler.Invoke(update);
                }).ReturnsAsync(mockToken.Object);

            return mockToken;
        }
        
        public Mock<IDisposable> Where_SubscribeAsync_publishes_immediately(IEnumerable<T> updates)
        {
            var mockToken = new Mock<IDisposable>();

            Mock.Setup(x => x.SubscribeAsync(It.IsAny<Func<T, Task>>(), It.IsAny<TId>()))
                .Callback(async (Func<T, Task> handler, long id) =>
                {
                    foreach (var update in updates)
                    {
                        await handler.Invoke(update);
                    }
                }).ReturnsAsync(mockToken.Object);

            return mockToken;
        }

        public Mock<IDisposable> Where_SubscribeAsync_publishes_sequence(IEnumerable<T> updates)
        {
            var mockToken = new Mock<IDisposable>();
            var queue = new Queue<T>(updates);

            Mock.Setup(x => x.SubscribeAsync(It.IsAny<Func<T, Task>>(), It.IsAny<TId>()))
                .Callback((Func<T, Task> handler, long id) =>
                {
                    handler.Invoke(queue.Dequeue());
                }).ReturnsAsync(mockToken.Object);

            return mockToken;
        }
         

        public async Task PublishMockSubscriptionAsync(T model)
        {
            foreach (var handler in _handlers)
            {
                await handler.Invoke(model);
            }
        }
    }




}