using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Blauhaus.Common.Abstractions;

namespace Blauhaus.Common.Utils.Disposables
{
   
    public abstract class BaseAsyncIdCollectionPublisher<T, TPublisher, TId> : BaseAsyncCollectionPublisher<TId, TId>, IAsyncIdCollectionPublisher<TId>
        where TPublisher : IAsyncPublisher<T> 
        where TId : IEquatable<TId>
        where T : class, IHasId<TId>
    {
        protected readonly TPublisher DtoCache;

        protected IDisposable? DtoToken;

        protected BaseAsyncIdCollectionPublisher(
            TPublisher dtoCache)
        {
            DtoCache = dtoCache;
        }

        public override async Task<IDisposable> SubscribeAsync(Func<IReadOnlyList<TId>, Task> handler, Func<IReadOnlyList<TId>, bool>? filter = null)
        {
            DtoToken ??= await DtoCache.SubscribeAsync(async dto =>
            {
                Items = await LoadItemsAsync(CollectionId);
                await UpdateSubscribersAsync(Items);
            });

            return base.SubscribeAsync(handler, filter);
        }


    }
}