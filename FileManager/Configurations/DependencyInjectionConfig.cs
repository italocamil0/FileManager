using FileManager.Business.Interfaces;
using FileManager.Data.Context;
using FileManager.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileManager.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IArquivoRepository, ArquivoRepository>();
            
            services.AddScoped<IFrequenciaExecucaoRepository, FrequenciaExecucaoRepository>();
            

            //services.AddScoped<INotificador, Notificador>();
            //services.AddScoped<IFornecedorService, FornecedorService>();
            //services.AddScoped<IProdutoService, ProdutoService>();

            return services;
        }
    }
}
