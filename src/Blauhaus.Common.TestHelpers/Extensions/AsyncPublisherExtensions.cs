using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blauhaus.Common.Abstractions; 
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Blauhaus.Common.TestHelpers.Extensions
{
    public static class AsyncPublisherExtensions
    {
        public static async Task<PublishedItems<T>> SubscribeToUpdatesAsync<T>(this IAsyncPublisher publisher, Func<T, bool>? filter = null)
        {
            var models = new PublishedItems<T>(publisher, filter);
            await models.InitializeAsync();
            return models;
        }

        public static async Task<PublishedItems<T>> SubscribeToLocalUpdatesAsync<T>(this IAsyncPublisher<T> publisher, Func<T, bool>? filter = null)
        {
            var models = new PublishedItems<T>(publisher, filter);
            await models.InitializeAsync();
            return models;
        }

        public class PublishedItems<T> : List<T>, IDisposable
        {
            private readonly IAsyncPublisher<T>? _publisher;
            private readonly IAsyncPublisher? _genericPublisher;
            private readonly Func<T, bool>? _filter;
            private IDisposable? _token;

            public PublishedItems(IAsyncPublisher genericPublisher, Func<T, bool>? filter = null)
            {
                _genericPublisher = genericPublisher;
                _filter = filter;
            }

            public PublishedItems(IAsyncPublisher<T> publisher, Func<T, bool>? filter = null)
            {
                _publisher = publisher;
                _filter = filter;
            }

            public async Task InitializeAsync()
            {

                if (_publisher is not null)
                {
                    _token = await _publisher.SubscribeAsync(update =>
                    {
                        //Serialize and Deserialize to create a copy of the object in case it gets modified later
                        try
                        {

                            Add(JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(update)) ?? throw new InvalidOperationException("Serialized update was null"));
                        }
                        catch (Exception)
                        {
                            if (update != null)
                            {
                                Console.WriteLine($"Unable to serialize {update.GetType()}");
                            }

                            Add(update);
                        }

                        return Task.CompletedTask;
                    }, _filter);
                }

                if (_genericPublisher is not null)
                {
                    _token = await _genericPublisher.SubscribeAsync(update =>
                    {
                        //Serialize and Deserialize to create a copy of the object in case it gets modified later
                        try
                        {
                            Add(JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(update)) ?? throw new InvalidOperationException("Serialized update was null"));
                        }
                        catch (Exception)
                        {
                            if (update != null)
                            {
                                Console.WriteLine($"Unable to serialize {update.GetType()}");
                            }

                            Add(update);
                        }

                        return Task.CompletedTask;
                    }, _filter);
                }
            }

            public void Dispose()
            {
                _token?.Dispose();
            }
        }
    }
}