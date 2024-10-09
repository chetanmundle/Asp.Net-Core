using App.Core.Interfaces;
using App.Core.Models;
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
    public class GetEmpByIdWithDepartment : IRequest<EmployeeWithDeptObjDto>
    {
        public int EmpId { get; set; }
    }

    public class GetEmpByIdWithDepartmentHandler : IRequestHandler<GetEmpByIdWithDepartment, EmployeeWithDeptObjDto>
    {
        private readonly IAppDbContext _appDbContext;

        public GetEmpByIdWithDepartmentHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<EmployeeWithDeptObjDto> Handle(GetEmpByIdWithDepartment request, CancellationToken cancellationToken)
        {
            int empId = request.EmpId;
            var employeeDto = await _appDbContext.Set<Domain.Employee>()
                                     .Include(e => e.Department)
                                     .Select(emp => new EmployeeWithDeptObjDto
                                     {
                                         Eid = emp.Eid,
                                         FirstName = emp.FirstName,
                                         LastName = emp.LastName,
                                         Salary = emp.Salary,
                                         Department = new DepartmentDto
                                         {
                                             DeptId = emp.Department.DeptId,
                                             Name = emp.Department.Name,
                                         }
                                     })
                                      .FirstOrDefaultAsync(emp => emp.Eid == empId);
            

            return employeeDto;
        }
    }
}
