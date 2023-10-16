﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Piadineria2.DbContexts;

#nullable disable

namespace Piadineria2.Migrations
{
    [DbContext(typeof(ProductInfoContext))]
    partial class ProductInfoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Piadineria2.Entities.BibitaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Prezzo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Bibite");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Coca Cola",
                            Prezzo = 2.00m,
                            Sku = "971b"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Fanta",
                            Prezzo = 2.00m,
                            Sku = "4236"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Pepsi",
                            Prezzo = 2.50m,
                            Sku = "192f"
                        });
                });

            modelBuilder.Entity("Piadineria2.Entities.IngredientEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("PiadinaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PiadinaId");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Prosciutto",
                            PiadinaId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Formaggio",
                            PiadinaId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tacchino",
                            PiadinaId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "Maionese",
                            PiadinaId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "Tacchino",
                            PiadinaId = 3
                        },
                        new
                        {
                            Id = 6,
                            Name = "Maionese",
                            PiadinaId = 3
                        },
                        new
                        {
                            Id = 7,
                            Name = "Formaggio",
                            PiadinaId = 3
                        });
                });

            modelBuilder.Entity("Piadineria2.Entities.PiadinaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Forma")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Prezzo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Piadine");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Forma = "Aperta",
                            Nome = "Piadina Prosciutto e Formaggio",
                            Prezzo = 5.50m
                        },
                        new
                        {
                            Id = 2,
                            Forma = "Rotolo",
                            Nome = "Piadina Tacchino e Maionese",
                            Prezzo = 6.00m
                        },
                        new
                        {
                            Id = 3,
                            Forma = "Aperta",
                            Nome = "Piadina MegaTwist",
                            Prezzo = 7.00m
                        });
                });

            modelBuilder.Entity("Piadineria2.Entities.SnackEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Prezzo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Snacks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Patatine",
                            Prezzo = 2.50m,
                            Sku = "087e"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Popcorn",
                            Prezzo = 5.00m,
                            Sku = "a46a"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Salsa",
                            Prezzo = 2.00m,
                            Sku = "ec7e"
                        });
                });

            modelBuilder.Entity("Piadineria2.Entities.IngredientEntity", b =>
                {
                    b.HasOne("Piadineria2.Entities.PiadinaEntity", "Piadina")
                        .WithMany("Ingredients")
                        .HasForeignKey("PiadinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Piadina");
                });

            modelBuilder.Entity("Piadineria2.Entities.PiadinaEntity", b =>
                {
                    b.Navigation("Ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}
