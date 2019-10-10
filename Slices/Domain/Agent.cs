using System;

namespace NeoFindR.Domain
{
    public class Agent : Entity
    {
        public Guid Id { get; set; }
        public DateTime LastRebooted { get; private set; }
        public Cache Cache { get; private set; }
        public string Name { get; set; }
        public DateTime LastCrashed { get; set; }

        public void Reboot()
        {
            LastRebooted = DateTime.Now;
            Cache = null;
            
            DomainEvents.Enqueue(new AgentRebootedEvent(Id));
        }
    }

    public class Cache : Entity
    {
    }
}