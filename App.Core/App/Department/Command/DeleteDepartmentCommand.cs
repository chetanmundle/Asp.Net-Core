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

namespace App.Core.App.Department.Command
{
    public class DeleteDepartmentCommand : IRequest<string>
    {
        public int DeptId { get; set; }
    }

    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, string>
    {
        private readonly IAppDbContext _appDbContext;

        public DeleteDepartmentCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var deptid = request.DeptId;

            var department = await _appDbContext.Set<Domain.Department>()
                                   .FirstOrDefaultAsync(d => d.DeptId == deptid);

            if (department == null) 
                return null;    

            _appDbContext.Set<Domain.Department>().Remove(department);

            await _appDbContext.SaveChangesAsync();

            

            return $"Department With Id = {department.DeptId} is Deleted Successfully";
        }
    }
}
