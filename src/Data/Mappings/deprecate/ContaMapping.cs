using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ContaMapping : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DescricaoFornecedor)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(p => p.TipoConta)
                .IsRequired();
            builder.Property(p => p.TipoRecorrencia)
             .IsRequired();

            builder.ToTable("Contas");

            // 1 : N => conta-pagamentos
            builder.HasMany(f => f.Pagamentos)
                   .WithOne(p => p.Conta)
                   .HasForeignKey(prop => prop.IdConta);


        }
    }
}
