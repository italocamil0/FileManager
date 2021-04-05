using FileManager.Infra.Security.Contexts;
using FileManager.Infra.Security.Interfaces;
using FileManager.Infra.Security.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileManager.Infra.Security.IoC
{
    public static class ServiceRegistration
    {
        public static void AddSecurityInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAccountService, AccountService>();
            

            services.AddDbContext<SecurityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
               b => b.MigrationsAssembly(typeof(SecurityDbContext).Assembly.FullName)));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<SecurityDbContext>();
        }
    }
}
