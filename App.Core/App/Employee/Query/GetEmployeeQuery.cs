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

namespace App.Core.App.Employee.Query
{
    public class GetEmployeeQuery : IRequest<List<EmployeeDto>>
    {

    }

    public class GetEmployeeQueryHandaler : IRequestHandler<GetEmployeeQuery, List<EmployeeDto>>
    {
        private readonly IAppDbContext _appdbContext;
        public GetEmployeeQueryHandaler(IAppDbContext appDbContext)
        {
            _appdbContext = appDbContext;
        }

        public async Task<List<EmployeeDto>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var listEmp = await _appdbContext.Set<Domain.Entities.Employee>()
                                .AsNoTracking()
                                .ToListAsync(cancellationToken);

            var result = listEmp.Adapt<List<EmployeeDto>>();


            return result;
        }
    }
}
