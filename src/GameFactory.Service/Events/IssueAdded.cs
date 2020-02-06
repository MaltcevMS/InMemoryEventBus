using GameFactory.Domain.Issue;

namespace GameFactory.Service.Events
{
    public class IssueAdded
    {
        public IssueAdded(IIssue issue)
        {
            Issue = issue;
        }

        public IIssue Issue { get; set; }
    }
}
