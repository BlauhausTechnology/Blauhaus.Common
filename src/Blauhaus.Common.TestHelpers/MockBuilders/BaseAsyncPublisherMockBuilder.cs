using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blauhaus.Common.Abstractions;
using Blauhaus.Common.Utils.Disposables;
using Blauhaus.TestHelpers.MockBuilders;
using Moq;

namespace Blauhaus.Common.TestHelpers.MockBuilders
{

    public abstract class BaseAsyncPublisherMockBuilder<TBuilder, TMock, T> : BaseMockBuilder<TBuilder, TMock>
        where TBuilder : BaseAsyncPublisherMockBuilder<TBuilder, TMock, T>
        where TMock : class, IAsyncPublisher<T>
    {
        private readonly List<Subscription> _subscriptions = new List<Subscription>();

        private class Subscription : BasePublisher
        {

            public Subscription(Func<T, Task> handler, Func<T, bool>? filter = null)
            {
                base.AddSubscriber(handler, filter);
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
                }).ReturnsAsync(MockToken.Object);
             
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