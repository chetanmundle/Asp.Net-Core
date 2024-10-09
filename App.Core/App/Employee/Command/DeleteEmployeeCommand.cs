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

    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, string>
    {
        public readonly IAppDbContext _appDbContext;
        public DeleteEmployeeCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            int empId = request.EmployeeId;

            var employee = await _appDbContext.Set<Domain.Employee>()
                                 .FirstOrDefaultAsync(e => e.Eid == empId);

            _appDbContext.Set<Domain.Employee>().Remove(employee);

            await _appDbContext.SaveChangesAsync();

            return $"Employee with id = {empId} Deleted Successfully";
        }
    }
}
