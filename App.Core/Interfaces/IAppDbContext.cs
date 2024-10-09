using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace App.Core.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
