using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NeoFindR.Domain;

namespace NeoFindR.Features.Agents.EventHandlers.AgentRebooted
{
    public class UpdateLogs : INotificationHandler<AgentRebootedEvent>
    {
        public async Task Handle(AgentRebootedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Rebooted Agent {notification.AgentId}");
        }
    }
}