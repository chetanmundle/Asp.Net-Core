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
    public class GetEmployeesQuery : IRequest<List<EmployeeDto>>
    {
        
    }

    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, List<EmployeeDto>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetEmployeesQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var listofEmployees = await _appDbContext.Set<Domain.Employee>()
                                        .AsNoTracking()
                                        .ToListAsync();

            var listOfEmpDto = listofEmployees.Adapt<List<EmployeeDto>>();

            return listOfEmpDto;
        }
    }
}
