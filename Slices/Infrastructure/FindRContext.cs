using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NeoFindR.Domain;

namespace NeoFindR.Infrastructure
{
    public class FindRContext : DbContext
    {
        private IMediator _mediator;

        public FindRContext(DbContextOptions options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }
        
        public DbSet<Inhabitant> Inhabitants { get; set; }
        public DbSet<Agent> Agents { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var entitiesWithEvents = ChangeTracker.Entries<IEntity>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                foreach (var @event in entity.DomainEvents.ToArray())
                {
                    await _mediator.Publish(@event, cancellationToken);
                }
            }
            
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

