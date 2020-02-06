using System.Threading.Tasks;

namespace InMemoryEventBus.Infrastructure
{
    public interface IEventBus
    {
        IEventBus Subscribe<T>();
        Task PublishAsync<T>(T @event);
    }
}