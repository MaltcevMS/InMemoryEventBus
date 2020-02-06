using GameFactory.Domain.Issue;
using System;

namespace GameFactory.Domain.IssuePipeline
{
    public class StatusHandler : IStatusHandler
    {
        public IssueStatuses ProcessableStatus { get; }
        private IStatusHandler _nextHandler = null;

        public StatusHandler(IssueStatuses processableStatus)
        {
            ProcessableStatus = processableStatus;
        }

        public void SetNextHandler(IStatusHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public IssueStatuses Handle(IssueStatuses status)
        {
            if (_nextHandler == null)
            {
                throw new ArgumentException($"Status {status} is not processable");
            }

            return status == ProcessableStatus ? 
                _nextHandler.ProcessableStatus : 
                _nextHandler.Handle(status);
        }
    }
}
