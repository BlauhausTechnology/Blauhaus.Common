using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blauhaus.Common.Abstractions;
using Blauhaus.Common.Utils.Disposables;
using Blauhaus.TestHelpers.MockBuilders;
using Moq;

namespace Blauhaus.Common.TestHelpers.MockBuilders
{

    public abstract class BaseUnfilteredAsyncPublisherMockBuilder<TBuilder, TMock, T> : BaseMockBuilder<TBuilder, TMock>
        where TBuilder : BaseUnfilteredAsyncPublisherMockBuilder<TBuilder, TMock, T>
        where TMock : class, IAsyncPublisher<T>
    {
        private readonly List<Func<T, Task>> _handlers = new List<Func<T, Task>>();

        public Mock<IDisposable> MockToken { get; }

        protected BaseUnfilteredAsyncPublisherMockBuilder()
        {
            MockToken = new Mock<IDisposable>();

            Mock.Setup(x => x.SubscribeAsync(It.IsAny<Func<T, Task>>(), It.IsAny<Func<T, bool>>()))
                .Callback((Func<T, Task> handler, Func<T, bool>? filter) =>
                {
                    _handlers.Add(handler);
                }).ReturnsAsync(MockToken.Object);
        }

        public TBuilder Where_SubscribeAsync_publishes_immediately(T update)
        {
            Mock.Setup(x => x.SubscribeAsync(It.IsAny<Func<T, Task>>(), It.IsAny<Func<T, bool>>()))
                .Callback(async (Func<T, Task> handler, Func<T, bool>? filter) =>
                {
                    await handler.Invoke(update);
                }).ReturnsAsync(MockToken.Object);

            return (TBuilder)this;
        }

        public TBuilder Where_SubscribeAsync_publishes_immediately(IEnumerable<T> updates)
        {
            Mock.Setup(x => x.SubscribeAsync(It.IsAny<Func<T, Task>>(), It.IsAny<Func<T, bool>>()))
                .Callback(async (Func<T, Task> handler, Func<T, bool>? filter) =>
                {
                    foreach (var update in updates)
                    {
                        await handler.Invoke(update);
                    }
                }).ReturnsAsync(MockToken.Object);

            return (TBuilder)this;
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