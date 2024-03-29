﻿using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.RazaoSocial)
                .IsRequired()
                .HasColumnType("varchar(250)");
            
            builder.Property(p => p.Cnpj)
              .IsRequired()
              .HasColumnType("varchar(14)");
            
            builder.Property(p => p.Atividade)
              .IsRequired()
              .HasColumnType("varchar(250)");
           

            builder.ToTable("Fornecedores");

            builder.Property(t => t.IdEndereco).IsRequired();
            builder.HasOne(e => e.Endereco)
                    .WithMany()
                    .HasForeignKey(i=> i.IdEndereco);
        }
    }
}
