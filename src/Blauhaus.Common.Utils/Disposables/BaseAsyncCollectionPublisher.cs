using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Blauhaus.Common.Abstractions;

namespace Blauhaus.Common.Utils.Disposables
{
    public abstract class BaseAsyncCollectionPublisher<T> : BasePublisher, IAsyncCollectionPublisher<T>
    {
        protected IReadOnlyList<T>? Items;

        public virtual async Task<IDisposable> SubscribeAsync(Func<IReadOnlyList<T>, Task> handler, Func<IReadOnlyList<T>, bool>? filter = null)
        {
            var disposable = AddSubscriber(handler, filter);
            
            await UpdateSubscribersAsync(Items);

            return disposable;
        }
         
        public async Task<IReadOnlyList<T>> GetCollectionAsync()
        {
            return Items ??= await LoadItemsAsync();
        }
        
        protected abstract Task<IReadOnlyList<T>> LoadItemsAsync();
    
    }
}