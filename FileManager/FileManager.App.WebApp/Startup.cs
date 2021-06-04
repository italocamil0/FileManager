using FileManager.Core.Adapters.ServiceBus;
using FileManager.Core.Application.Persistence;
using FileManager.Core.Application.Port;
using FileManager.Core.Application.Service;
using FileManager.Infra.Persistence;
using FileManager.Infra.Persistence.Context;
using FileManager.Infra.Security.IoC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FileManager.App.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSecurityInfrastructure(Configuration);

            services.AddDbContext<MeuDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(Startup));


            
            services.AddScoped<IArquivosRepository, ArquivosRepository>();
            services.AddScoped<IFrequenciaExecucaoRepository, FrequenciaExecucaoRepository>();
            services.AddScoped<IPrefixoRepository, PrefixoRepository>();
            services.AddScoped<ICamposRepository, CamposRepository>();
            services.AddScoped<ISendMessagePort, ServiceBus>();
            services.AddScoped<IArquivosPort, ArquivosService>();
            services.AddScoped<IFrequenciaExecucaoPort, FrequenciaExecucaoService>();
            services.AddScoped<IPrefixoPort, PrefixoService>();
            services.AddScoped<ICamposPort, CamposService>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddControllersWithViews(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                       .RequireAuthenticatedUser()
                       .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
