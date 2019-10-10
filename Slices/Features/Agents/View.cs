using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NeoFindR.Infrastructure;

namespace NeoFindR.Features.Agents
{
    public class View
    {
        public class Query : IRequest<Model>
        {
        }

        public class Model
        {
            public List<Agent> Agents { get; set; }

            public class Agent
            {
                public string Name { get; set; }
                public DateTime LastRebooted { get; set; }
                public DateTime LastCrashed { get; set; }
            }
        }

        public class QueryHandler : IRequestHandler<Query, Model>
        {
            private readonly FindRContext _dbContext;

            public QueryHandler(FindRContext context)
            {
                _dbContext = context;
            }

            public async Task<Model> Handle(Query request, CancellationToken cancellationToken)
            {
                return new Model
                {
                    Agents = await _dbContext.Agents.Select(x => new Model.Agent
                    {
                        Name = x.Name,
                        LastRebooted = x.LastRebooted,
                        LastCrashed = x.LastCrashed
                    }).ToListAsync(cancellationToken: cancellationToken)
                };
            }
        }
    }
}