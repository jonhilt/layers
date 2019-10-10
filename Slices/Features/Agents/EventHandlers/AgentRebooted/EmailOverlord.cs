using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NeoFindR.Domain;

namespace NeoFindR.Features.Agents.EventHandlers.AgentRebooted
{
    public class EmailOverlord : INotificationHandler<AgentRebootedEvent>
    {
        public async Task Handle(AgentRebootedEvent notification, CancellationToken cancellationToken)
        {
            // send email to someone
        }
    }
}