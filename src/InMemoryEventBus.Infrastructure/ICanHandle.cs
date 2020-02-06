using System.Threading.Tasks;

namespace InMemoryEventBus.Infrastructure
{
    public interface ICanHandle<in T>
    {
        Task<bool> TryHandleAsync(T @event);
    }
}
