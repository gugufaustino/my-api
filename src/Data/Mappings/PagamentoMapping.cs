using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mappings
{
    public class PagamentoMapping : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.HasKey(p => p.Id);

            //builder.Property(p => p.IdConta)


            builder.Property(p => p.DtVencimento)
                    .IsRequired();

            builder.Property(p => p.Valor)
                    .IsRequired();

            builder.Property(p => p.Saldo)
                    .IsRequired();

            builder.Property(p => p.IndPago)
                    .IsRequired();

            builder.ToTable("Pagamentos");          

        }
    }
}
