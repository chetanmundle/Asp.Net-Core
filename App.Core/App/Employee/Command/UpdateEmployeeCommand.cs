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
    public class UpdateEmployeeCommand : IRequest<EmployeeDto>
    {
        public EmployeeDto EmployeeDto { get; set; }
    }

    public class UpdateEmployeeCommandHandalar : IRequestHandler<UpdateEmployeeCommand, EmployeeDto>
    {
        private readonly IAppDbContext _appDbContext;

        public UpdateEmployeeCommandHandalar(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<EmployeeDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var model = request.EmployeeDto;

            var existingEmployee = await _appDbContext.Set<Domain.Entities.Employee>()
                                         .FirstOrDefaultAsync(emp => emp.EmpId == model.EmpId);

            if(existingEmployee == null)
                return null;

            existingEmployee.EmpName = model.EmpName;
            existingEmployee.EmpSalary = model.EmpSalary;

            _appDbContext.SaveChangesAsync();

            var result = existingEmployee.Adapt<EmployeeDto>();

            return result;
        }
    }
}
