using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reactivities.Reactivities.Domain;
using Reactivities.Reactivities.Persistence;

namespace Reactivities.Reactivities.Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }

            public class Handler : IRequestHandler<Command>
            {
                private readonly DataContext _context;
                public Handler(DataContext context)
                {
                    _context = context;

                }
                public async Task<Unit> Handle(
                    Command request, 
                    CancellationToken cancellationToken)
                {
                    _context.Activities.Add(request.Activity);

                    await _context.SaveChangesAsync();

                    return Unit.Value;
                }
            }
        }
    }
}