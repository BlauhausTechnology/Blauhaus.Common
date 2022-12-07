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
                .Callback(async (Func<T, Task> handler, Func<T, bool>? filter) =>
                {
                    _subscriptions.Add(new Subscription(handler, filter));
                    if (_resultsToPublish != null)
                    {
                        foreach (var result in _resultsToPublish)
                        {
                            await PublishMockSubscriptionAsync(result);
                        }
                    }
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


    public abstract class BaseAsyncPublisherMockBuilder<TBuilder, TMock> : BaseMockBuilder<TBuilder, TMock>
            where TBuilder : BaseAsyncPublisherMockBuilder<TBuilder, TMock>
            where TMock : class, IAsyncPublisher
        {
            private readonly Dictionary<string, object> _subscriptions = new();
 
            private class Subscription<T> : BasePublisher
            {
                public Subscription(Func<T, Task> handler, Func<T, bool>? filter = null)
                {
                    AddSubscriber(handler, filter);
                }
                 
                public async Task UpdateAsync(T update)
                {
                    await UpdateSubscribersAsync(update);
                }
                
                public T[]? ResultsToPublish;
                public Func<T>? ResultFactoryToPublish;
                public IBuilder<T>[]? ResultBuilders;

            }
    
            public Mock<IDisposable> MockToken { get; }

            protected BaseAsyncPublisherMockBuilder()
            {
                MockToken = new Mock<IDisposable>();
            }
    
            protected void Setup<T>()
            {
                Mock.Setup(x => x.SubscribeAsync<T>(It.IsAny<Func<T, Task>>(), It.IsAny<Func<T, bool>>()))
                    .Callback(async (Func<T, Task> handler, Func<T, bool>? filter) =>
                    {
                        if(!_subscriptions.TryGetValue(typeof(T).Name, out var subscription))
                        {
                             subscription = new Subscription<T>(handler, filter);
                             _subscriptions[typeof(T).Name] = new Subscription<T>(handler, filter);
                        }

                        Subscription<T> sub  = (Subscription<T>)subscription;
                        
                        if (sub.ResultsToPublish != null)
                        {
                            foreach (var result in sub.ResultsToPublish)
                            {
                                await PublishMockSubscriptionAsync(result);
                            }
                        }
                        if (sub.ResultFactoryToPublish is not null)
                        {
                            await PublishMockSubscriptionAsync(sub.ResultFactoryToPublish.Invoke());
                        }
                        if (sub.ResultBuilders is not null)
                        {
                            foreach (var resultBuilder in sub.ResultBuilders)
                            {
                                await PublishMockSubscriptionAsync(resultBuilder.Object);
                            }
                        }

                        _subscriptions[typeof(T).Name] = subscription;
                    }).ReturnsAsync(MockToken.Object);
            }

            public void Verify_SubscribeAsync<T>(int times = 1)
            {
                Mock.Verify(x => x.SubscribeAsync(It.IsAny<Func<T, Task>>(), It.IsAny<Func<T, bool>>()), Times.Exactly(times));
            }

            private Subscription<T> GetSubscription<T>()
            {
                if(!_subscriptions.TryGetValue(typeof(T).Name, out var subscription))
                {
                    throw new Exception("AsyncPublisherMockBuilder must be setup to publish type " + typeof(T).Name);
                }

                return (Subscription<T>)subscription;
            }
            public TBuilder Where_SubscribeAsync_publishes<T>(params T[] results)
            {
                GetSubscription<T>().ResultsToPublish = results;
                return (TBuilder)this;
            }
            public TBuilder Where_SubscribeAsync_publishes<T>(Func<T> resultFunc)
            {
                GetSubscription<T>().ResultFactoryToPublish = resultFunc;
                return (TBuilder)this;
            }
            
            public TBuilder Where_SubscribeAsync_publishes<T>(params IBuilder<T>[] resultBuilders)
            {
                GetSubscription<T>().ResultBuilders = resultBuilders;
                return (TBuilder)this;
            }
              
            public async Task PublishMockSubscriptionAsync<T>(T model)
            { 
                foreach (var sub in _subscriptions)
                {
                    var pub = (Subscription<T>)sub.Value;
                    await pub.UpdateAsync(model);
                }
            }
            
        }
}