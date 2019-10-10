using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NeoFindR.Infrastructure;

namespace NeoFindR.Features.Agents
{
    public class Reboot
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class CommandHandler : AsyncRequestHandler<Command>
        {
            private readonly FindRContext _dbContext;

            public CommandHandler(FindRContext dbContext)
            {
                _dbContext = dbContext;
            }

            protected override async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var agent = await _dbContext.Agents.FindAsync(request.Id);
                agent.Reboot();
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}