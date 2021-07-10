﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrincaChurrasco.Infra.Data;

namespace TrincaChurrasco.Infra.Migrations
{
    [DbContext(typeof(TrincaChurrascoContext))]
    partial class TrincaChurrascoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TrincaChurrasco.Domain.Models.Churrasco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Observacao")
                        .HasColumnType("varchar(300)");

                    b.Property<decimal>("ValorComBebida")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("ValorSemBebida")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.ToTable("Churrasco");
                });

            modelBuilder.Entity("TrincaChurrasco.Domain.Models.Participante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChurrascoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("ChurrascoId");

                    b.ToTable("Participante");
                });

            modelBuilder.Entity("TrincaChurrasco.Domain.Models.Participante", b =>
                {
                    b.HasOne("TrincaChurrasco.Domain.Models.Churrasco", "Churrasco")
                        .WithMany("Participantes")
                        .HasForeignKey("ChurrascoId")
                        .IsRequired();

                    b.Navigation("Churrasco");
                });

            modelBuilder.Entity("TrincaChurrasco.Domain.Models.Churrasco", b =>
                {
                    b.Navigation("Participantes");
                });
#pragma warning restore 612, 618
        }
    }
}
