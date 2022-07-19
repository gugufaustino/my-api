using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class AgenciaEmpresaMapping : IEntityTypeConfiguration<AgenciaEmpresa>
    {

        public void Configure(EntityTypeBuilder<AgenciaEmpresa> builder)
        {
            builder.HasKey(p => p.Id);            
            builder.Property(t => t.Id).ValueGeneratedNever();            


            builder.Property(p => p.RazaoSocial)
                    .IsRequired()
                    .HasColumnType("varchar(500)");

            builder.Property(p => p.Cnpj)
                    .IsRequired();

            builder.Property(p => p.NomeFantasia)
                    .IsRequired()
                    .HasColumnType("varchar(250)");
            
            builder.Property(p => p.Email)
                    .IsRequired()
                    .HasColumnType("varchar(250)");

            builder.ToTable("AgenciasEmpresa");


            



        }

    }
}
