using System;
using MediatR;

namespace NeoFindR.Domain
{
    public class AgentRebootedEvent : INotification
    {
        public Guid AgentId { get; set; }
        public AgentRebootedEvent(Guid id)
        {
            AgentId = id;
        }
    }
}