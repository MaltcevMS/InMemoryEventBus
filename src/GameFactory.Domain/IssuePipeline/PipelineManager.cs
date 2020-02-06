using GameFactory.Domain.Issue;

namespace GameFactory.Domain.IssuePipeline
{
    public class PipelineManager : IPipelineManager
    {
        private readonly IStatusHandler _initialStatusHandler;

        public PipelineManager()
        {
            var notStartedHandler = new StatusHandler(IssueStatuses.NotStarted);
            var inAnalysisHandler = new StatusHandler(IssueStatuses.InAnalysis);
            var inProgressHandler = new StatusHandler(IssueStatuses.InProgress);
            var inReviewHandler = new StatusHandler(IssueStatuses.InReview);
            var doneHandler = new StatusHandler(IssueStatuses.Done);
            var releasedHandler = new StatusHandler(IssueStatuses.Released);

            notStartedHandler.SetNextHandler(inAnalysisHandler);
            inAnalysisHandler.SetNextHandler(inProgressHandler);
            inProgressHandler.SetNextHandler(inReviewHandler);
            inReviewHandler.SetNextHandler(doneHandler);
            doneHandler.SetNextHandler(releasedHandler);

            _initialStatusHandler = notStartedHandler;
        }

        public IssueStatuses HandleStatus(IssueStatuses status)
        {
            return _initialStatusHandler.Handle(status);
        }
    }
}
