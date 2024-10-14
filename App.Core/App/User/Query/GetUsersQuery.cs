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

namespace App.Core.App.User.Query
{
    public class GetUsersQuery : IRequest<List<UserDto>>
    {

    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>>
    {
        private readonly IAppDbcontext _dbcontext;
        

        public GetUsersQueryHandler(IAppDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var listofUsers = await _dbcontext.
                                    FromSqlRaw<Domain.Entities.User>("exec getAllUser")
                                    .ToListAsync(cancellationToken: cancellationToken);

            var resultlist = listofUsers.Adapt<List<UserDto>>();

            return resultlist;
        }
    }
}
