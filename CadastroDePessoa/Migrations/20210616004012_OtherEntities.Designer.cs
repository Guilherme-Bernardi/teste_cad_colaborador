﻿// <auto-generated />
using System;
using CadastroDePessoa.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CadastroDePessoa.Migrations
{
    [DbContext(typeof(CadastroDePessoaContext))]
    [Migration("20210616004012_OtherEntities")]
    partial class OtherEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CadastroDePessoa.Models.Colaborador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPF");

                    b.Property<int?>("DepartamentoId");

                    b.Property<string>("Nome");

                    b.Property<double>("Salario");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Colaborador");
                });

            modelBuilder.Entity("CadastroDePessoa.Models.Departamentos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("CadastroDePessoa.Models.Colaborador", b =>
                {
                    b.HasOne("CadastroDePessoa.Models.Departamentos", "Departamento")
                        .WithMany("Colaboradores")
                        .HasForeignKey("DepartamentoId");
                });
#pragma warning restore 612, 618
        }
    }
}