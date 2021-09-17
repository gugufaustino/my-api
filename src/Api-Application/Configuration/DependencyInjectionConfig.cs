using Business.Interface;
using Business.Interface.Repository;
using Business.Interface.Services;
using Business.Notifications;
using Business.Services;
using Data.Contexto;
using Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ApiApplication.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            services.AddScoped<IBroadcaster, Broadcaster>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IContaService, ContaService>();
            services.AddScoped<IPagamentoService, PagamentoService>();
            services.AddScoped<IFornecedorService, FornecedorService>();

            
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            //services.AddScoped<IUsuarioRepository, UsuarioRepositoryFake>();

            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();



            return services;
        }
    }

}