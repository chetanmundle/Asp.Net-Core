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

namespace App.Core.App.Employee.Command
{
    public class CreateEmployeeCommand : IRequest<EmployeeDto>
    {
        public EmployeeDto EmployeeDto { get; set; }    
    }

    public class CreateEmployeeCommandHadler : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
    {
        private readonly IAppDbContext _appDbContext;

        public CreateEmployeeCommandHadler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var empModel =  request.EmployeeDto;

            var employee = empModel.Adapt<Domain.Employee>();


            var getdepartment = await _appDbContext.Set<Domain.Department>()
                                      .FirstOrDefaultAsync(d => d.DeptId==employee.DepId);

            if (getdepartment == null)
            {
                throw new InvalidOperationException($"Department with ID {employee.DepId} not found");
            }       

            employee.Department = getdepartment;


            var result = await _appDbContext.Set<Domain.Employee>().AddAsync(employee);
                              
            await _appDbContext.SaveChangesAsync(cancellationToken);

            var resultEmpDto = result.Entity.Adapt<EmployeeDto>();

            return resultEmpDto;
        }
    }
}
