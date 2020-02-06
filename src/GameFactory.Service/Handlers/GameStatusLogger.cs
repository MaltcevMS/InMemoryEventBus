using System.Threading.Tasks;
using Common.Infrastructure;
using InMemoryEventBus.Infrastructure;
using GameFactory.Service.Events;

namespace GameFactory.Service.Handlers
{
    public class GameStatusLogger : ICanHandle<IssueAdded>, ICanHandle<IssueStatusChanged>
    {
        private readonly IGameLogger _logger;

        public GameStatusLogger(IGameLogger logger)
        {
            _logger = logger;
        }

        public async Task<bool> TryHandleAsync(IssueAdded @event)
        {
            _logger.Info($"Issue {@event.Issue} is added");

            return await Task.FromResult(true).ConfigureAwait(false);
        }

        public async Task<bool> TryHandleAsync(IssueStatusChanged @event)
        {
            _logger.Info($"Status for issue {@event.Issue} is changed to {@event.NewStatus}");
            return await Task.FromResult(true).ConfigureAwait(false);
        }
    }
}
