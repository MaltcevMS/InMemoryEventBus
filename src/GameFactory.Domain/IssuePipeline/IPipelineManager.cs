using GameFactory.Domain.Issue;

namespace GameFactory.Domain.IssuePipeline
{
    public interface IPipelineManager
    {
        IssueStatuses HandleStatus(IssueStatuses status);
    }
}