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
    public class UpdateDepartmentCommand : IRequest<DepartmentDto>
    {
        public DepartmentDto Department { get; set; }
    }

    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, DepartmentDto>
    {
        private readonly IAppDbContext _appDbContext;

        public UpdateDepartmentCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<DepartmentDto> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var model = request.Department;

            var department = await _appDbContext.Set<Domain.Department>()
                                   .FirstOrDefaultAsync(d => d.DeptId == model.DeptId);

            if (department == null) 
                return null;

            department.Name = model.Name;

            await _appDbContext.SaveChangesAsync();

            var result = department.Adapt<DepartmentDto>();

            return result;
        }
    }
}
