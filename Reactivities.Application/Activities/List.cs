using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Reactivities.Reactivities.Domain;
using Reactivities.Reactivities.Persistence;

namespace Reactivities.Reactivities.Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Activity>> Handle(
                Query request, 
                CancellationToken cancellationToken)
            {
                return await _context
                    .Activities
                    .ToListAsync(cancellationToken)
                    .ConfigureAwait(false);
            }
        }
    }
}