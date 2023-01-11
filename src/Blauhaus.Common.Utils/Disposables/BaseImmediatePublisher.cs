using Blauhaus.Common.Abstractions;
using System.Threading.Tasks;
using System;

namespace Blauhaus.Common.Utils.Disposables
{
    public abstract class BaseImmediatePublisher<T> : BasePublisher, IAsyncPublisher<T>
    {
        public virtual async Task<IDisposable> SubscribeAsync(Func<T, Task> handler, Func<T, bool>? filter = null)
        {
            var token = AddSubscriber(handler, filter);
            var t = await GetAsync();
            if (t is not null)
            {
                await UpdateSubscribersAsync(t); 
            }
            return token;
        }

        protected abstract Task<T?> GetAsync();
    }
}