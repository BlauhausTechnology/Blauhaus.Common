using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Blauhaus.Common.Abstractions;

namespace Blauhaus.Common.Utils.Disposables
{
    public abstract class BaseAsyncCollectionPublisher<T> : BaseImmediatePublisher<IReadOnlyList<T>>, IAsyncCollectionPublisher<T>
    {
        protected List<T>? Items;
         
        public async Task<IReadOnlyList<T>> GetCollectionAsync()
        {
            return await GetAsync();
        }

        public async Task AddItemAsync(T item)
        {
            if (Items is null)
            {
                var items = await LoadItemsAsync();
                Items = new List<T>(items);
            }
            Items.Add(item);
            await UpdateSubscribersAsync(Items);
        }

        public async Task RemoveItemAsync(T item)
        {
            if (Items is null)
            {
                var items = await LoadItemsAsync();
                Items = new List<T>(items);
            }
            Items.Remove(item);
            await UpdateSubscribersAsync(Items);
        }

        protected override async Task<IReadOnlyList<T>> GetAsync()
        {
            if (Items is null)
            {
                var items = await LoadItemsAsync();
                Items = new List<T>(items);
            }

            return Items;
        }
        protected abstract Task<IEnumerable<T>> LoadItemsAsync();

    }
}