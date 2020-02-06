using System;
using System.Threading.Tasks;
using Common.Infrastructure;
using GameFactory.Domain.Issue;
using GameFactory.Domain.IssuePipeline;
using GameFactory.Service.Events;
using GameFactory.Service.Handlers;
using InMemoryEventBus.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace InMemoryEventBus
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IEventBus, EventBus>()
                .AddSingleton<IPipelineManager, PipelineManager>()
                .AddSingleton<IGameLogger, ConsoleGameLogger>()
                .AddSingleton<GameDeveloper>()
                .AddSingleton<GameStatusLogger>()
                .BuildServiceProvider();

            var eventBus = serviceProvider.GetService<IEventBus>();
            eventBus.Subscribe<GameDeveloper>();
            eventBus.Subscribe<GameStatusLogger>();

            Task.Run(() => eventBus.PublishAsync(new IssueAdded(new Feature("Game menu", 2))));

            Console.ReadLine();
        }
    }
}
