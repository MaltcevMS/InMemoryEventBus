using GameFactory.Domain.Issue;

namespace GameFactory.Domain.IssuePipeline
{
    public interface IStatusHandler
    {
        IssueStatuses ProcessableStatus { get; }
        void SetNextHandler(IStatusHandler nextHandler);
        IssueStatuses Handle(IssueStatuses status);
    }
}
