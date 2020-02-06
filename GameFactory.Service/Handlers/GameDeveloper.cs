using System.Threading.Tasks;
using GameFactory.Domain.IssuePipeline;
using InMemoryEventBus.Infrastructure;
using GameFactory.Service.Events;
using GameFactory.Domain.Issue;
using GameFactory.Domain.Issue.Extensions;

namespace GameFactory.Service.Handlers
{
    public class GameDeveloper : ICanHandle<IssueAdded>, ICanHandle<IssueStatusChanged>
    {
        private readonly IEventBus _eventBus;
        private readonly IPipelineManager _pipelineManager;

        public GameDeveloper(IEventBus eventBus, IPipelineManager pipelineManager)
        {
            _eventBus = eventBus;
            _pipelineManager = pipelineManager;
        }

        public async Task<bool> TryHandleAsync(IssueAdded @event)
        {
            await _eventBus.PublishAsync(new IssueStatusChanged(@event.Issue, IssueStatuses.NotStarted));

            return true;
        }

        public async Task<bool> TryHandleAsync(IssueStatusChanged @event)
        {
            var status = @event.NewStatus;
            var issue = @event.Issue;

            if (!IsAbleToHandleStatus(status))
            {
                return false;
            }

            await HandleIssue(issue).ConfigureAwait(false);
            await _eventBus.PublishAsync(new IssueStatusChanged(issue, _pipelineManager.HandleStatus(status)));

            return true;
        }

        private static bool IsAbleToHandleStatus(IssueStatuses status)
        {
            return status.Is(IssueStatuses.DeveloperStatus);
        }

        private static async Task HandleIssue(IIssue issue)
        {
            await Task.Delay(issue.StoryPoints * 1000).ConfigureAwait(false);
        }
    }
}
