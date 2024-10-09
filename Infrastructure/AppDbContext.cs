using App.Core.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourseMapping> StudentCourseMapping { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=SDN-274\\SQLEXPRESS2017;Database=StudentDb;User Id=sa;Password=admin@123;MultipleActiveResultSets=true;Max Pool Size=256;TrustServerCertificate=True");
            //optionsBuilder.LogTo(Console.WriteLine);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Student>()
            //    .HasMany<StudentCourseMapping>()

            base.OnModelCreating(modelBuilder);
        }
    }
}
