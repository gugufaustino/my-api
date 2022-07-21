﻿// <auto-generated />
using System;
using Data.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Business.Models.Agencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Instagram")
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("NomeAgencia")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("TipoCadastro")
                        .HasColumnType("int");

                    b.Property<int>("TipoSituacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Agencias");
                });

            modelBuilder.Entity("Business.Models.AgenciaEmpresa", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("Cnpj")
                        .IsUnique();

                    b.ToTable("AgenciasEmpresa");
                });

            modelBuilder.Entity("Business.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Business.Models.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescricaoFornecedor")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("TipoConta")
                        .HasColumnType("int");

                    b.Property<int>("TipoRecorrencia")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("Business.Models.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("varchar(11)");

                    b.HasKey("Id");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("Business.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Cep")
                        .HasMaxLength(9)
                        .IsUnicode(false)
                        .HasColumnType("varchar(9)");

                    b.Property<string>("Complemento")
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<string>("Logradouro")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("NomeMunicipio")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.Property<int?>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("SiglaUf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2)");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Business.Models.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Atividade")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(14)");

                    b.Property<int>("IdEndereco")
                        .HasColumnType("int");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("IdEndereco");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("Business.Models.Modelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Altura")
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(14)");

                    b.Property<int>("CorCabelo")
                        .HasColumnType("int");

                    b.Property<int>("CorOlhos")
                        .HasColumnType("int");

                    b.Property<string>("Diponibilidade")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("DtNascimento")
                        .HasColumnType("date");

                    b.Property<DateTime>("DthAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DthInclusao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Facebook")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("IdEndereco")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoSituacao")
                        .HasColumnType("int");

                    b.Property<string>("ImagemPerfilNome")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Instagram")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Linkedin")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("Manequim")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.Property<string>("Rg")
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Sapato")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<int>("TipoCabelo")
                        .HasColumnType("int");

                    b.Property<int>("TipoCabeloComprimento")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioAtualizacao")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("UsuarioInclusao")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("IdEndereco");

                    b.HasIndex("IdTipoSituacao");

                    b.ToTable("Modelos");
                });

            modelBuilder.Entity("Business.Models.ModeloTipoCasting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdModelo")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoCasting")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdModelo");

                    b.HasIndex("IdTipoCasting");

                    b.ToTable("ModelosTipoCasting");
                });

            modelBuilder.Entity("Business.Models.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DtVencimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdConta")
                        .HasColumnType("int");

                    b.Property<bool>("IndPago")
                        .HasColumnType("bit");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdConta");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("Business.Models.TipoCasting", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("NomeTipoCasting")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("TipoCasting");
                });

            modelBuilder.Entity("Business.Models.TipoSituacao", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("NomeTipoSituacao")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("TipoSituacao");
                });

            modelBuilder.Entity("Business.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apelido")
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("IdAgencia")
                        .HasColumnType("int");

                    b.Property<string>("Imagem")
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Telefone")
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<int>("TipoCadastro")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAgencia");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Business.Models.AgenciaEmpresa", b =>
                {
                    b.HasOne("Business.Models.Agencia", "Agencia")
                        .WithOne("AgenciaEmpresa")
                        .HasForeignKey("Business.Models.AgenciaEmpresa", "Id")
                        .IsRequired();

                    b.Navigation("Agencia");
                });

            modelBuilder.Entity("Business.Models.Fornecedor", b =>
                {
                    b.HasOne("Business.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("IdEndereco")
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Business.Models.Modelo", b =>
                {
                    b.HasOne("Business.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("IdEndereco")
                        .IsRequired();

                    b.HasOne("Business.Models.TipoSituacao", "TipoSituacao")
                        .WithMany()
                        .HasForeignKey("IdTipoSituacao")
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("TipoSituacao");
                });

            modelBuilder.Entity("Business.Models.ModeloTipoCasting", b =>
                {
                    b.HasOne("Business.Models.Modelo", "Modelo")
                        .WithMany("ModeloTipoCasting")
                        .HasForeignKey("IdModelo")
                        .IsRequired();

                    b.HasOne("Business.Models.TipoCasting", "TipoCasting")
                        .WithMany()
                        .HasForeignKey("IdTipoCasting")
                        .IsRequired();

                    b.Navigation("Modelo");

                    b.Navigation("TipoCasting");
                });

            modelBuilder.Entity("Business.Models.Pagamento", b =>
                {
                    b.HasOne("Business.Models.Conta", "Conta")
                        .WithMany("Pagamentos")
                        .HasForeignKey("IdConta")
                        .IsRequired();

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("Business.Models.Usuario", b =>
                {
                    b.HasOne("Business.Models.Agencia", "Agencia")
                        .WithMany("Usuario")
                        .HasForeignKey("IdAgencia");

                    b.Navigation("Agencia");
                });

            modelBuilder.Entity("Business.Models.Agencia", b =>
                {
                    b.Navigation("AgenciaEmpresa");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Business.Models.Conta", b =>
                {
                    b.Navigation("Pagamentos");
                });

            modelBuilder.Entity("Business.Models.Modelo", b =>
                {
                    b.Navigation("ModeloTipoCasting");
                });
#pragma warning restore 612, 618
        }
    }
}
