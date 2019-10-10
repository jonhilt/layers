using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NeoFindR.Domain;
using NeoFindR.Infrastructure;

namespace NeoFindR.Features.Inhabitants
{
    public class Destroy
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class CommandHandler : AsyncRequestHandler<Command>
        {
            private readonly FindRContext findRContext;

            public CommandHandler(FindRContext dbContext)
            {
                findRContext = dbContext;
            }
            
            protected override async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var inhabitant = await findRContext.Inhabitants.FindAsync(request.Id);
                findRContext.Inhabitants.Remove(inhabitant);
                await findRContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}