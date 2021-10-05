using System;
using System.Threading.Tasks;
using Blauhaus.Common.Abstractions;
using Blauhaus.Common.Utils.Disposables;

namespace Blauhaus.Common.Tests.Tests.PiblisherTests.Sut
{
    public class TestBasePublisher : BasePublisher, IAsyncPublisher<TestObject>
    {
        public Task<IDisposable> SubscribeAsync(Func<TestObject, Task> handler, Func<TestObject, bool>? filter = null)
        {
            return Task.FromResult(base.AddSubscriber(handler, filter));
        }

        public async Task UpdateAsync(TestObject obj)
        {
            await UpdateSubscribersAsync(obj);
        }
    }
}