using System.Threading.Tasks;

namespace InMemoryEventBus.Infrastructure
{
    public interface ICanHandleAsync<in T>
    {
        Task<bool> TryHandle(T @event);
    }
}
