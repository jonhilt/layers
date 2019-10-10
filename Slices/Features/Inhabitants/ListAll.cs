using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace NeoFindR.Features.Inhabitants
{
    public class ListAll
    {
        public class Query : IRequest<Model>
        {
        }

        public class Model
        {
            public List<Inhabitant> Inhabitants { get; set; }

            public class Inhabitant
            {
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public DateTime LastSlept { get; set; }
                public string ThreatLevel { get; set; }
            }
        }

        public class QueryHandler : IRequestHandler<Query, Model>
        {
            public async Task<Model> Handle(Query request, CancellationToken cancellationToken)
            {
                return new Model
                {
                    Inhabitants = new List<Model.Inhabitant>
                    {
                        new Model.Inhabitant
                        {
                            FirstName = "Not",
                            LastName = "The One",
                            LastSlept = new DateTime(),
                            ThreatLevel = "Inconsequential"
                        }
                    }
                };
            }
        }
    }
}