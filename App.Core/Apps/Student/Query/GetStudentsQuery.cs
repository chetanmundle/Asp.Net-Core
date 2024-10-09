using App.Core.Interfaces;
using App.Core.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace App.Core.Apps.Student.Query
{
    public class GetStudentsQuery : IRequest<List<StudentDto>>
    {
    }

    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, List<StudentDto>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetStudentsQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<StudentDto>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var list = await _appDbContext.Set<Domain.Student>()
                .AsNoTracking()
                .ToListAsync();

            return list.Adapt<List<StudentDto>>();
        }
    }
}
