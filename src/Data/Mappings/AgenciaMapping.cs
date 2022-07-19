using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class AgenciaMapping : IEntityTypeConfiguration<Agencia>
    {

        public void Configure(EntityTypeBuilder<Agencia> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NomeAgencia)
                    .IsRequired()
                    .HasColumnType("varchar(250)");
            
            builder.Property(p => p.Instagram)                    
                    .HasColumnType("varchar(250)");

            builder.Property(p => p.TipoCadastro)
                    .IsRequired();
            
            builder.Property(p => p.IdEmpresa);

            builder.ToTable("Agencias");

            // 1 : N =>
            builder.HasMany(f => f.Usuario)
               .WithOne(p => p.Agencia)
               .HasForeignKey(prop => prop.IdAgencia);


            builder.HasOne(f => f.AgenciaEmpresa)
                    .WithOne(p => p.Agencia)
                    .HasForeignKey<Agencia>(pr => pr.IdEmpresa);

        }

    } 
}
