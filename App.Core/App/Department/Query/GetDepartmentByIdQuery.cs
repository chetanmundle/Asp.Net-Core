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
    public class GetDepartmentByIdQuery : IRequest<DepartmentDto>
    {
        public int DeptID { get; set; }
    }

    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentDto>
    {
        private readonly IAppDbContext _appDbContext;

        public GetDepartmentByIdQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<DepartmentDto> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
           int deptId = request.DeptID;

            var department = await _appDbContext.Set<Domain.Department>()
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync(d => d.DeptId == deptId);

            var result = department.Adapt<DepartmentDto>();

            return result;


        }
    }
}
