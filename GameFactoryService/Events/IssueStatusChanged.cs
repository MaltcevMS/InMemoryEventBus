using GameFactory.Domain.Issue;

namespace GameFactory.Service.Events
{
    public class IssueStatusChanged
    {
        public IIssue Issue { get;}
        public IssueStatuses NewStatus { get; }

        public IssueStatusChanged(IIssue issue, IssueStatuses newStatus)
        {
            Issue = issue;
            NewStatus = newStatus;
        }
    }
}
