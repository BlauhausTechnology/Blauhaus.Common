using System;
using System.Threading.Tasks;
using Blauhaus.Common.Abstractions.Extensions;

namespace Blauhaus.Common.Utils.Disposables
{
    public abstract class BaseMultiPublisher : BasePublisher, IAsyncMultiPublisher
    {
        public async Task<IDisposable> SubscribeAsync<T>(Func<T, Task> handler, bool publishImmediately = true)
        {
            var disposable = base.AddSubscriber<T>(handler);
            
            return disposable;
        }
    }
}