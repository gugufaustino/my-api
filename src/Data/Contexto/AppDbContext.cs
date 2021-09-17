using Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public DbSet<Fornecedor> Fornecedor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                        .Where(w => w.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(1)");
            }

            // mappeia todas classes mappings de uma vez só
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            //Impedindo exclusão em cascata
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e=> e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}
