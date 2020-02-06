using System;

namespace GameFactory.Domain.Issue
{
    public enum IssueStatuses
    {
        NotStarted = 1 << 0,
        InAnalysis = 1 << 1,
        InProgress = 1 << 2,
        InReview = 1 << 3,
        Done = 1 << 4,
        Released = 1 << 5,

        DeveloperStatus = NotStarted | InAnalysis | InProgress,
        ManagerStatus = InReview | Done | Released
    }
}
