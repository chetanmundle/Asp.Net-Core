using App.Core.Interfaces;
using App.Core.Models;
using Domain;
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
    public class UpdateEmployeeCommand : IRequest<EmployeeDto>
    {
        public EmployeeDto EmployeeDto { get; set; }
    }

    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeDto>
    {
        private readonly IAppDbContext _appDbContext;

        public UpdateEmployeeCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<EmployeeDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var empModel = request.EmployeeDto;

            var existingEmp = await _appDbContext.Set<Domain.Employee>()
                                    .FirstOrDefaultAsync(e => e.Eid == empModel.Eid);

            if(existingEmp ==  null) 
                return null;

            if(existingEmp.DepId != empModel.DepId)
            {

                var getdepartment = await _appDbContext.Set<Domain.Department>()
                                          .FirstOrDefaultAsync(d => d.DeptId == empModel.DepId);

                existingEmp.Department = getdepartment;
            }

            existingEmp.FirstName = empModel.FirstName;
            existingEmp.LastName = empModel.LastName;
            existingEmp.Salary  = empModel.Salary;
            existingEmp.DepId = empModel.DepId;

           await _appDbContext.SaveChangesAsync(cancellationToken);

            var resultEmpDto = existingEmp.Adapt<EmployeeDto>(); 
            
            return resultEmpDto;
        }
    }
}
