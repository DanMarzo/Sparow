﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WEB_API_HealTime.Data;

#nullable disable

namespace WEBAPIHealTime.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WEB_API_HealTime.Models.Pessoas", b =>
                {
                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<string>("BairroEnderecoPessoa")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("CepEndereco")
                        .IsRequired()
                        .HasColumnType("char(8)");

                    b.Property<string>("CidadeEnderecoPessoa")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("ComplementoPessoa")
                        .HasColumnType("varchar(45)");

                    b.Property<string>("EnderecoPessoa")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<int>("GeneroPessoa")
                        .HasColumnType("int");

                    b.Property<string>("NomePessoa")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("ObsPacienteIncapaz")
                        .HasColumnType("varchar(350)");

                    b.Property<string>("SobrenomePessoa")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<int>("TipoPessoa")
                        .HasColumnType("int");

                    b.Property<int>("UfEndereco")
                        .HasColumnType("int");

                    b.Property<DateTime>("dtNascimentoPesssoa")
                        .HasColumnType("date");

                    b.HasKey("PessoaId");

                    b.ToTable("Pessoas");
                });
#pragma warning restore 612, 618
        }
    }
}