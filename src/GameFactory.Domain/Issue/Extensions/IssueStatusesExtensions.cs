using System;

namespace GameFactory.Domain.Issue.Extensions
{
    public static class IssueStatusesExtensions
    {
        public static bool Is(this IssueStatuses status, IssueStatuses comparingStatus)
        {
            return (status & comparingStatus) != 0;
        }

        public static bool IsNot(this IssueStatuses status, IssueStatuses comparingStatus)
        {
            return !status.Is(comparingStatus);
        }
    }
}
