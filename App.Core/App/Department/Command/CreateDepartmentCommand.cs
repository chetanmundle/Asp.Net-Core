using App.Core.Interfaces;
using App.Core.Models;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Core.App.Department.Command
{
    public class CreateDepartmentCommand : IRequest<DepartmentDto>
    {
        public DepartmentDto Department { get; set; }
    }

    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, DepartmentDto>
    {
        private readonly IAppDbContext _aapdbContext;

        public CreateDepartmentCommandHandler(IAppDbContext appDbContext)
        {
            _aapdbContext = appDbContext;
        }
        public async Task<DepartmentDto> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var deptDto = request.Department;

            var department = deptDto.Adapt<Domain.Department>();

            var deptResponse = await _aapdbContext.Set<Domain.Department>().AddAsync(department);

            await _aapdbContext.SaveChangesAsync();

            var resultDto = department.Adapt<DepartmentDto>();

            return resultDto;
        }
    }
}
