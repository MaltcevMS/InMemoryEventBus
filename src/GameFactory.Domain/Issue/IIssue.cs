using System;

namespace GameFactory.Domain.Issue
{
    public interface IIssue
    {
        Guid Id { get; }
        string Name { get; }
        int StoryPoints { get; }
    }
}
