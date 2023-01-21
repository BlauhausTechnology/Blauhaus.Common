using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blauhaus.Common.Abstractions;
using Blauhaus.TestHelpers.Builders.Base;
using Blauhaus.TestHelpers.MockBuilders;
using Moq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Blauhaus.Common.TestHelpers.Extensions
{
    public static class AsyncCollectionPublisherMockBuilderExtensions
    {
        public static IAsyncCollectionPublisherSetup<T> SetupCollectionPublisher<TBuilder, TMock, T>(this TBuilder builder)
            where TMock : class, IAsyncCollectionPublisher 
            where TBuilder : IMockBuilder<TBuilder, TMock>
        {
            return new AsyncCollectionPublisherSetup<TBuilder, TMock, T>(builder);
        }
    }

    public interface IAsyncCollectionPublisherSetup<in T>
    {
        public Mock<IDisposable> MockToken { get; }
        Task PublishMockSubscriptionAsync(T update);
        Task PublishMockSubscriptionAsync(IEnumerable<T> update);
    }

    public class AsyncCollectionPublisherSetup<TBuilder, TMock, T> : IAsyncCollectionPublisherSetup<T>
        where TMock : class, IAsyncCollectionPublisher
        where TBuilder : IMockBuilder<TBuilder, TMock>
    {
        private readonly TBuilder _mockBuilder;
        private readonly List<Func<IReadOnlyList<T>, Task>> _handlers = new();

        public AsyncCollectionPublisherSetup(TBuilder mockBuilder)
        {
            _mockBuilder = mockBuilder;
            MockToken = new Mock<IDisposable>();

            mockBuilder.Mock.Setup(x => x.SubscribeToCollectionAsync<T>(It.IsAny<Func<IReadOnlyList<T>, Task>>(), It.IsAny<Func<T, bool>>()))
                .Callback((Func<IReadOnlyList<T>, Task> handler, Func<T, bool> filter) =>
                { 
                    _handlers.Add(handler);
                }).ReturnsAsync(MockToken.Object);;
        }
        
        public Mock<IDisposable> MockToken { get; }

        
        public TBuilder Where_SubscribeAsync_publishes_immediately(T update)
        {
            _mockBuilder.Mock.Setup(x => x.SubscribeToCollectionAsync(It.IsAny<Func<IReadOnlyList<T>, Task>>(), It.IsAny<Func<T, bool>>()))
                .Callback(async (Func<IReadOnlyList<T>, Task> handler, Func<T, bool> filter) =>
                {
                    _handlers.Add(handler);
                    await handler.Invoke(new []{update});
                }).ReturnsAsync(MockToken.Object);

            return _mockBuilder;
        }
        
        public TBuilder Where_SubscribeAsync_publishes_immediately(T[] update)
        {
            _mockBuilder.Mock.Setup(x => x.SubscribeToCollectionAsync(It.IsAny<Func<IReadOnlyList<T>, Task>>(), It.IsAny<Func<T, bool>>()))
                .Callback(async (Func<IReadOnlyList<T>, Task> handler, Func<T, bool> filter) =>
                {
                    _handlers.Add(handler);
                    await handler.Invoke(update);
                }).ReturnsAsync(MockToken.Object);

            return _mockBuilder;
        }
        public TBuilder Where_SubscribeAsync_publishes_immediately(IBuilder<T> update)
        {
            _mockBuilder.Mock.Setup(x => x.SubscribeToCollectionAsync(It.IsAny<Func<IReadOnlyList<T>, Task>>(), It.IsAny<Func<T, bool>>()))
                .Callback(async (Func<IReadOnlyList<T>, Task> handler, Func<T, bool> filter) =>
                {
                    _handlers.Add(handler);
                    await handler.Invoke(new []{update.Object});
                }).ReturnsAsync(MockToken.Object);

            return _mockBuilder;
        }

        public TBuilder Where_SubscribeAsync_publishes_immediately(IEnumerable<T> updates)
        {
            _mockBuilder.Mock.Setup(x => x.SubscribeToCollectionAsync(It.IsAny<Func<IReadOnlyList<T>, Task>>(), It.IsAny<Func<T, bool>>()))
                .Callback(async (Func<IReadOnlyList<T>, Task> handler, Func<T, bool> filter) =>
                {
                    _handlers.Add(handler);
                    await handler.Invoke(updates.ToArray());
                }).ReturnsAsync(MockToken.Object);

            return _mockBuilder;
        }

        public async Task PublishMockSubscriptionAsync(T update)
        {
            foreach (var handler in _handlers)
            {
                await handler.Invoke(new []{update});
            }
        }
        
        public async Task PublishMockSubscriptionAsync(IEnumerable<T> update)
        {
            var updates = update.ToArray();
            foreach (var handler in _handlers)
            {
                await handler.Invoke(updates);
            }
        }
    }
 
}