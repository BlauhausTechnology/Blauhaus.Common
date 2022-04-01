using Blauhaus.Common.Abstractions;
using System.Threading.Tasks;
using System;

namespace Blauhaus.Common.Utils.Disposables
{
    public abstract class BaseImmediatePublisher<T> : BasePublisher, IAsyncPublisher<T>
    {
        public async Task<IDisposable> SubscribeAsync(Func<T, Task> handler, Func<T, bool>? filter = null)
        {
            var token = AddSubscriber(handler, filter);
            await UpdateSubscribersAsync(await GetAsync());
            return token;
        }

        protected abstract Task<T> GetAsync();
    }
}