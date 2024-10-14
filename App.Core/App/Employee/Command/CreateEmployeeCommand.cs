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

namespace App.Core.App.Employee.Command
{
    public class CreateEmployeeCommand : IRequest<EmployeeDto>     // IRequest<EmployeeDto> ? EmployeeDto = what return
    {
        public EmployeeDto EmployeeDto { get; set; }
    }

    public class CreateEmployeeCommandHandaler : IRequestHandler<CreateEmployeeCommand, EmployeeDto> // first is Request , second is return
    {
        private readonly IAppDbContext _appDbContext;

        public CreateEmployeeCommandHandaler( IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var model = request.EmployeeDto;

            var employee = model.Adapt<Domain.Entities.Employee>();

            await _appDbContext.Set<Domain.Entities.Employee>().AddAsync(employee);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            var resultEmpDto = employee.Adapt<EmployeeDto>();

            return resultEmpDto;
        }
    }
}
