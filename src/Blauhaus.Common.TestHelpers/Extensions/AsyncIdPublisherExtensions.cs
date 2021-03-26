using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blauhaus.Common.Abstractions;

namespace Blauhaus.Common.TestHelpers.Extensions
{
    public class PublishedIdModels<TUpdate, TId> : List<TUpdate>, IDisposable 
    {
        private readonly IAsyncIdPublisher<TUpdate, TId> _publisher;
        private readonly TId _id;
        private IDisposable? _token;

        public PublishedIdModels(IAsyncIdPublisher<TUpdate, TId> publisher, TId id)
        {
            _publisher = publisher;
            _id = id;
        }
         
        public async Task InitializeAsync()
        {
            _token = await _publisher.SubscribeAsync(update =>
            {
                Add(update);
                return Task.CompletedTask;
            }, _id);
        }
        
        public void Dispose()
        {
            _token?.Dispose();
        }
    }
    
    public static class AsyncIdPublisherExtensions
    {
        public static async Task<PublishedIdModels<T, TId>> SubscribeToUpdates<T, TId>(this IAsyncIdPublisher<T, TId> publisher, TId id)
        {
            var models = new PublishedIdModels<T, TId>(publisher, id);
            await models.InitializeAsync();
            return models;
        } 
    }
}