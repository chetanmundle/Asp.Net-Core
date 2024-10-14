using App.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Core.App.User.Query
{
    public class GetSepreateUserAndDepartment : IRequest<Object>
    {

    }

    public class GetSepreateUserAndDepartmentHandler : IRequestHandler<GetSepreateUserAndDepartment,Object>
    {
        private readonly IAppDbcontext _dbcontext;

        public GetSepreateUserAndDepartmentHandler(IAppDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<object> Handle(GetSepreateUserAndDepartment request, CancellationToken cancellationToken)
        {
            var department = await _dbcontext
                              .FromSqlRaw<Domain.Entities.Department>("CallTwoSelectProcedure")
                              .ToListAsync();

            var users = await _dbcontext
                                   .FromSqlRaw<Domain.Entities.User>("CallTwoSelectProcedure")
                                   .Skip(1)
                                   .ToListAsync();
            return department;
        }
    }
}
