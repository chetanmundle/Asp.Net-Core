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
    public class GetEmployeeByIdQuery : IRequest<EmployeeDto>
    {
        public int Empid { get; set; }
    }

    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        private readonly IAppDbContext _appDbContext;

        public GetEmployeeByIdQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
           int empid = request.Empid;

            var result = await _appDbContext.Set<Domain.Employee>().FirstOrDefaultAsync(e => e.Eid == empid);   

            var resultDto = result.Adapt<EmployeeDto>();
            return resultDto;
        }
    }
}
