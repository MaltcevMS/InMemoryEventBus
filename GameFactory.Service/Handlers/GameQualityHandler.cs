using System.Threading.Tasks;
using GameFactory.Service.Events;
using InMemoryEventBus.Infrastructure;

namespace GameFactory.Service.Handlers
{
    public class GameQualityHandler : ICanHandle<GameUpdated>
    {
        public async Task<bool> TryHandleAsync(GameUpdated @event)
        {
            return true;
        }
    }
}
