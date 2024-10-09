using Domain.Emp;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class EmpDbContext : DbContext
    {
        public EmpDbContext(DbContextOptions<EmpDbContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
