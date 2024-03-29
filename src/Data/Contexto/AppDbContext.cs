﻿using Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Contexto
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<TipoSituacao> TipoSituacao { get; set; }
        //public DbSet<ModeloTipoCasting> ModeloTipoCasting { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //aplica padrão para entidades nao mapeadas
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()))
            {
                if (property.ClrType == typeof(string))
                    property.SetColumnType("varchar(1)");

                if (property.ClrType == typeof(decimal) || property.ClrType == typeof(decimal?))
                    property.SetColumnType("decimal(18,2)");
            }

            // mappeia todas classes mappings de uma vez só
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            //apos mapeamento, substitui as mapeadas nvarchar para varchar
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties()))
            {
                if (property.ClrType == typeof(string))
                    property.SetIsUnicode(false);

            }

            //Impedindo exclusão em cascata
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}
