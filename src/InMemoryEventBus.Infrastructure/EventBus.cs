﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InMemoryEventBus.Infrastructure
{
    public class EventBus : IEventBus
    {
        private readonly IList<Type> _subscribedEventHandlerTypes;
        private readonly IServiceProvider _serviceProvider;

        public EventBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _subscribedEventHandlerTypes = new List<Type>();
        }

        public IEventBus Subscribe<T>()
        {
            _subscribedEventHandlerTypes.Add(typeof(T));
            return this;
        }

        public async Task PublishAsync<T>(T @event)
        {
            foreach (var handler in GetHandlers<T>())
            {
                await handler.TryHandleAsync(@event).ConfigureAwait(false);
            }
        }

        private IEnumerable<ICanHandle<T>> GetHandlers<T>()
        {
            foreach (var handlerType in _subscribedEventHandlerTypes)
            {
                if (typeof(ICanHandle<T>).IsAssignableFrom(handlerType))
                {
                    yield return (ICanHandle<T>) _serviceProvider.GetService(handlerType);
                }
            }
        }
    }
}
