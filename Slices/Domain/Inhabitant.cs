using System;

namespace NeoFindR.Domain
{
    public class Inhabitant : Entity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastSlept { get; set; }
        public string CurrentThreatLevel { get; set; }
    }
}