﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fact.Migrations
{
    [DbContext(typeof(facturasContext))]
    partial class facturasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("facturas", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreFat")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RNC")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("total")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Facturas");
                });
#pragma warning restore 612, 618
        }
    }
}
