using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Core.Interfaces
{
    public interface IAppDbcontext
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        IQueryable<TEntity> FromSqlRaw<TEntity>(string sql, params object[] parameters) 
            where TEntity : class;


    }
}
