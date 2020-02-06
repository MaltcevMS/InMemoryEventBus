using System;

namespace GameFactory.Domain.Issue
{
    public class Feature : IIssue
    {
        public Guid Id { get; }
        public string Name { get; }
        public int StoryPoints { get; }

        public Feature(string name, int storyPoints)
        {
            Id = Guid.NewGuid();
            Name = name;
            StoryPoints = storyPoints;
        }

        public override string ToString()
        {
            return $"feature/{Name}";
        }
    }
}
