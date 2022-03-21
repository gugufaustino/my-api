using Business.Interface;
using Business.Interface.Repository;
using Business.Interface.Services;
using Business.Models;
using Business.Notifications;
using Business.Services;
using Business.Services.Validations;
using Data.Contexto;
using Data.Repository;
using FluentValidation;
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
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IClienteService, ClienteService>();

            services.AddScoped<IValidator<Fornecedor>, FornecedorValidation>();
            
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            //services.AddScoped<IUsuarioRepository, UsuarioRepositoryFake>();

            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();



            return services;
        }
    }

}