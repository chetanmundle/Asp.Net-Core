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
    public class GetEmployeeWithDepartmentQuery : IRequest<List<EmployeeWithDeptObjDto>>
    {

    }

    public class GetEmployeeWithDepartmentQueryHandler : 
        IRequestHandler<GetEmployeeWithDepartmentQuery, List<EmployeeWithDeptObjDto>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetEmployeeWithDepartmentQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<EmployeeWithDeptObjDto>> Handle(GetEmployeeWithDepartmentQuery request, CancellationToken cancellationToken)
        {
            var employees = await _appDbContext.Set<Domain.Employee>()
                                  .Include(x => x.Department)
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
                                      },

                                  })
                                  .ToListAsync();
                  

            return employees;
        }
    }
}
