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
    public class GetEmployeeByIdQuery : IRequest<EmployeeDto>
    {
        public int EmpId { get; set; }
    }

    public class GetEmployeeByIdQueryHandaler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        private readonly IAppDbContext _appdbContext;

        public GetEmployeeByIdQueryHandaler(IAppDbContext appdbContext)
        {
            _appdbContext = appdbContext;
        }

        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var empId = request.EmpId;

            var employee = await _appdbContext.Set<Domain.Entities.Employee>()
                           .AsNoTracking()
                           .FirstOrDefaultAsync(emp => emp.EmpId == empId);

            var empDto = employee.Adapt<EmployeeDto>();

            return empDto;
            
        }
    }
}
