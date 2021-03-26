using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blauhaus.Common.Abstractions;

namespace Blauhaus.Common.TestHelpers.Extensions
{
    public class PublishedIdModels<TUpdate, TId> : List<TUpdate>, IDisposable 
    {
        private readonly IDisposable? _token;

        public PublishedIdModels(IAsyncIdPublisher<TUpdate, TId> bindableObject, TId id)
        {
            _token = Task.Run(async () => await bindableObject.SubscribeAsync(update =>
            {
                Add(update);
                return Task.CompletedTask;
            }, id));
        }
         
        public void Dispose()
        {
            _token?.Dispose();
        }
    }
    
    public static class AsyncIdPublisherExtensions
    {
        public static PublishedIdModels<T, TId> SubscribeToUpdates<T, TId>(this IAsyncIdPublisher<T, TId> publisher, TId id)
        {
            return new PublishedIdModels<T, TId>(publisher, id);
        } 
    }
}