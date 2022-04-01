using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Blauhaus.Common.Abstractions;

namespace Blauhaus.Common.Utils.Disposables
{
    public abstract class BaseAsyncCollectionPublisher<T> : BaseImmediatePublisher<IReadOnlyList<T>>, IAsyncCollectionPublisher<T>
    {
        protected IReadOnlyList<T>? Items;
         
        public async Task<IReadOnlyList<T>> GetCollectionAsync()
        {
            return Items ??= await LoadItemsAsync();
        }
        
        protected abstract Task<IReadOnlyList<T>> LoadItemsAsync();
    }
}