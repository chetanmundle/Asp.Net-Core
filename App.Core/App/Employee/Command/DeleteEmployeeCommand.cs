using App.Core.Interfaces;
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
    public class DeleteEmployeeCommand : IRequest<string>
    {
        public int EmployeeId { get; set; }
    }

    public class DeleteEmployeeCommandHadler : IRequestHandler<DeleteEmployeeCommand, string>
    {
        private readonly IAppDbContext _appDbContext;
        public DeleteEmployeeCommandHadler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var empId = request.EmployeeId;
            var employee = await _appDbContext.Set<Domain.Entities.Employee>()
                           .FirstOrDefaultAsync();

            _appDbContext.Set<Domain.Entities.Employee>().Remove(employee);

            _appDbContext.SaveChangesAsync();

            return $"Employee with Id = {empId} is Deleted Sucessfully";
        }
    }
}
