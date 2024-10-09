using App.Core.App.Employee.Query;
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

namespace App.Core.App.Department.Query
{
    public class GetDepartmentQuery : IRequest<List<DepartmentDto>>
    {
        
    }

    public class GetDepartmentQueryHandler : IRequestHandler<GetDepartmentQuery, List<DepartmentDto>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetDepartmentQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<DepartmentDto>> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            var listofEmployees = await _appDbContext.Set<Domain.Department>()
                                        .AsNoTracking()
                                        .ToListAsync();

            var listOfEmpDto = listofEmployees.Adapt<List<DepartmentDto>>();

            return listOfEmpDto;
        }
    }
}
