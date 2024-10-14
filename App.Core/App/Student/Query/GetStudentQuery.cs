using App.Core.Interfaces;
using App.Core.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Core.App.Student.Query
{
    public class GetStudentQuery : IRequest<List<StudentDto>>
    {
       
    }

    public class GetStudentQueryHandeler : IRequestHandler<GetStudentQuery,List<StudentDto>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetStudentQueryHandeler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<StudentDto>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var list = await _appDbContext.Set<Domain.Student>()
                       .AsNoTracking()
                       .ToListAsync();
           return list.Adapt<List<StudentDto>>();
        }
    }
}
