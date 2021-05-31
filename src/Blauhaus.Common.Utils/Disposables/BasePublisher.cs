﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blauhaus.Common.Utils.Disposables
{
    public abstract class BasePublisher
    {
        
        private Dictionary<string, List<Func<object, Task>>>? _subscriptions;
        
        
        private IDisposable AddSubscription<T>(Func<T, Task> handler, string subscriptionName,  Func<T, bool>? filter = null)
        {
            _subscriptions ??= new Dictionary<string, List<Func<object, Task>>>();

            if (!_subscriptions.ContainsKey(subscriptionName))
            {
                _subscriptions[subscriptionName] = new List<Func<object, Task>>();
            }

            Task Subscription(object updateObject)
            {
                var update = (T) updateObject;

                if (filter != null)
                {
                    return filter.Invoke(update)
                        ? handler.Invoke(update)
                        : Task.CompletedTask;
                }

                return handler.Invoke(update);
            }

            _subscriptions[subscriptionName].Add(Subscription);

            return new ActionDisposable(() =>
            {
                _subscriptions[subscriptionName].Remove(Subscription);
            });
        }

        protected IDisposable AddSubscriber<T>(Func<T, Task> handler, Func<T, bool>? filter = null)
        {
            return AddSubscription(handler, GetName<T>(), filter); 
        }
        protected IDisposable AddSubscriber<T>(Func<T, Task> handler, string name, Func<T, bool>? filter = null)
        {
            return AddSubscription(handler, name, filter); 
        }

        protected async Task UpdateSubscribersAsync<T>(T update)
        {
            if (_subscriptions != null  && _subscriptions.Count > 0 && update != null)
            {
                var subscriptionName = GetName<T>();
                var subscriptions = _subscriptions.Where(sub => sub.Key == subscriptionName).Select(x => x.Value);
                 
                foreach (var subscription in subscriptions)
                {
                    foreach (var func in subscription)
                    {
                        await func.Invoke(update);
                    }
                } 
            }
        }
         
        private static string GetName<T>()
        {
            return typeof(T).Name.TrimStart('I');
        }
         
    }
}