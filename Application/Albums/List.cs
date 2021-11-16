using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.DBConnectionFactory;

namespace Application.Albums
{
    public class List
    {
        public class Query : IRequest<List<Album>> { }

        public class Handler : IRequestHandler<Query, List<Album>>
        {
            private readonly DataContext _dataContext;

            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<List<Album>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dataContext.Albums.ToListAsync();
            }
        }
    }
}