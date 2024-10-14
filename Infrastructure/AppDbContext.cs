using App.Core.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AppDbContext : DbContext, IAppDbcontext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Department> Departments { get; set; }

        // for Running Sql Queryes like Stroed Procedure
        public IQueryable<TEntity> FromSqlRaw<TEntity>(string sql, params object[] parameters) where TEntity : class
        {
            
            return Set<TEntity>().FromSqlRaw(sql, parameters);
        }

        

    
    }
}
