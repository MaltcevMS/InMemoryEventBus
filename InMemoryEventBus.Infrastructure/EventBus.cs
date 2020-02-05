using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace InMemoryEventBus.Infrastructure
{
    public class EventBus : IEventBus
    {
        private readonly IList<Type> _subscribedEventHandlerTypes;
        private readonly IServiceProvider _serviceProvider;

        public EventBus(IList<Type> subscribedEventHandlerTypes, IServiceProvider serviceProvider)
        {
            _subscribedEventHandlerTypes = subscribedEventHandlerTypes;
            _serviceProvider = serviceProvider;
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
                await handler.TryHandle(@event).ConfigureAwait(false);
            }
        }

        private IEnumerable<ICanHandleAsync<T>> GetHandlers<T>()
        {
            foreach (var handlerType in _subscribedEventHandlerTypes)
            {
                if (typeof(ICanHandleAsync<T>).IsAssignableFrom(handlerType))
                {
                    yield return (ICanHandleAsync<T>) _serviceProvider.GetService(handlerType);
                }
            }
        }
    }
}
