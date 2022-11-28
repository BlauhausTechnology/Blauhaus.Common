using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blauhaus.Common.Abstractions;
using Blauhaus.Common.Utils.Disposables;
using Blauhaus.TestHelpers.Builders.Base;
using Blauhaus.TestHelpers.MockBuilders;
using Moq;

namespace Blauhaus.Common.TestHelpers.MockBuilders
{

    public abstract class BaseAsyncPublisherMockBuilder<TBuilder, TMock, T> : BaseMockBuilder<TBuilder, TMock>
        where TBuilder : BaseAsyncPublisherMockBuilder<TBuilder, TMock, T>
        where TMock : class, IAsyncPublisher<T>
    {
        private readonly List<Subscription> _subscriptions = new();
        private T[]? _resultsToPublish;
        private Func<T>? _resultFactoryToPublish;
        private IBuilder<T>[]? _resultBuilders;

        private class Subscription : BasePublisher
        {

            public Subscription(Func<T, Task> handler, Func<T, bool>? filter = null)
            {
                AddSubscriber(handler, filter);
            }
             
            public async Task UpdateAsync(T update)
            {
                await UpdateSubscribersAsync(update);
            }
        }

        public Mock<IDisposable> MockToken { get; }

        protected BaseAsyncPublisherMockBuilder()
        {
            MockToken = new Mock<IDisposable>();

            Mock.Setup(x => x.SubscribeAsync(It.IsAny<Func<T, Task>>(), It.IsAny<Func<T, bool>>()))
                .Callback((Func<T, Task> handler, Func<T, bool>? filter) =>
                {
                    _subscriptions.Add(new Subscription(handler, filter));
                    Task.Run(async () =>
                    {
                        if (_resultsToPublish != null)
                        {
                            if (_resultFactoryToPublish is not null)
                            {
                                await PublishMockSubscriptionAsync(_resultFactoryToPublish.Invoke());
                            }

                            if (_resultBuilders is not null)
                            {
                                foreach (var resultBuilder in _resultBuilders)
                                {
                                    await PublishMockSubscriptionAsync(resultBuilder.Object);
                                }
                            }
                            foreach (var result in _resultsToPublish)
                            {
                                await PublishMockSubscriptionAsync(result);
                            }
                        }                        
                    }).GetAwaiter().GetResult();
                    
                }).ReturnsAsync(MockToken.Object);
             
        }

        public void Verify_SubscribeAsync(int times = 1)
        {
            Mock.Verify(x => x.SubscribeAsync(It.IsAny<Func<T, Task>>(), It.IsAny<Func<T, bool>>()), Times.Exactly(times));
        }

        public TBuilder Where_SubscribeAsync_publishes(params T[] results)
        {
            _resultsToPublish = results;
            return (TBuilder)this;
        }
        public TBuilder Where_SubscribeAsync_publishes(Func<T> resultFunc)
        {
            _resultFactoryToPublish = resultFunc;
            return (TBuilder)this;
        }
        
        public TBuilder Where_SubscribeAsync_publishes(params IBuilder<T>[] resultBuilders)
        {
            _resultBuilders = resultBuilders;
            return (TBuilder)this;
        }
          
        public async Task PublishMockSubscriptionAsync(T model)
        { 
            foreach (var sub in _subscriptions)
            {
                await sub.UpdateAsync(model);
            }
        }
    }


}