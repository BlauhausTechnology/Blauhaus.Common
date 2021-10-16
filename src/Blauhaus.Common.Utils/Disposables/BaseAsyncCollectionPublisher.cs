using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Blauhaus.Common.Abstractions;

namespace Blauhaus.Common.Utils.Disposables
{
    //todo one without IAsyncInitializeable?
    public abstract class BaseAsyncCollectionPublisher<T, TId> : BasePublisher, IAsyncCollectionPublisher<T, TId>
        where TId : IEquatable<TId>
    {
        protected IReadOnlyList<T>? Items;
        protected TId CollectionId = default!;

        private bool _isInitialized;

        public virtual async Task<IDisposable> SubscribeAsync(Func<IReadOnlyList<T>, Task> handler, Func<IReadOnlyList<T>, bool>? filter = null)
        {
            var disposable = AddSubscriber(handler, filter);
            
            await UpdateSubscribersAsync(Items);

            return disposable;
        }

        public async Task InitializeAsync(TId collectionId)
        {
            CollectionId = collectionId;
            Items = await LoadItemsAsync(CollectionId);

            if (_isInitialized)
            {
                //todo compare Id?
                //todo only update if collection changed?
                //Change in CollectionId so Update subscribers
                await UpdateSubscribersAsync(Items);
            }


            _isInitialized = true;
        }
         
        public async Task<IReadOnlyList<T>> GetCollectionAsync()
        {
            return Items ??= await LoadItemsAsync(CollectionId);
        }
        
        protected abstract Task<IReadOnlyList<T>> LoadItemsAsync(TId collectionId);
    
    }
}