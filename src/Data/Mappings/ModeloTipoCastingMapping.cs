using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ModeloTipoCastingMapping : IEntityTypeConfiguration<ModeloTipoCasting>
    {

        public void Configure(EntityTypeBuilder<ModeloTipoCasting> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(p => p.IdTipoCasting).IsRequired();
            builder.Property(p => p.IdModelo).IsRequired();


            builder.ToTable("ModelosTipoCasting");
        }

    }
}
