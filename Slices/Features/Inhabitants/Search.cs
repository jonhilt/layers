using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NeoFindR.Domain;
using NeoFindR.Infrastructure;

namespace NeoFindR.Features.Inhabitants
{
    public class Search
    {
        public class Query : IRequest<Model>
        {
            public string Term { get; set; }
        }

        public class Model
        {
            public List<SearchResult> Results { get; set; }

            public class SearchResult
            {
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public DateTime LastSlept { get; set; }
                public string ThreatLevel { get; set; }
            }
        }

        public class QueryHandler : IRequestHandler<Query, Model>
        {
            private readonly FindRContext _dbContext;

            public QueryHandler(FindRContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Model> Handle(Query request, CancellationToken cancellationToken)
            {
                IQueryable<Inhabitant> results;

                if (string.IsNullOrEmpty(request.Term))
                    results = _dbContext.Inhabitants.Take(10);
                else
                    results = _dbContext.Inhabitants.Where(x =>
                        x.FirstName.Contains(request.Term) || x.LastName.Contains(request.Term));

                return new Model
                {
                    Results = results.Select(result => new Model.SearchResult
                    {
                        FirstName = result.FirstName,
                        LastName = result.LastName,
                        LastSlept = result.LastSlept,
                        ThreatLevel = result.CurrentThreatLevel
                    }).ToList()
                };
            }
        }
    }
}