using App.Core;
using App.Core.Interfaces;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddScoped<IAppDbContext, AppDbContext>();
            services.AddTransient<IStudentService, StudentService>();

            services.AddDbContext<AppDbContext>((provider, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
            });

            services.AddDbContext<EmpDbContext>((provider, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("EmplpoyeeConnection"),
                    b => b.MigrationsAssembly(typeof(EmpDbContext).Assembly.FullName));
            });

            return services;
        }
    }
}
