﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductsCategories.Models;

namespace ProductsCategories.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProductsCategories.Models.Category", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("CatId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ProductsCategories.Models.ProdCat", b =>
                {
                    b.Property<int>("ProdCatId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CatId");

                    b.Property<int>("ProdId");

                    b.HasKey("ProdCatId");

                    b.HasIndex("CatId");

                    b.HasIndex("ProdId");

                    b.ToTable("ProdCats");
                });

            modelBuilder.Entity("ProductsCategories.Models.Product", b =>
                {
                    b.Property<int>("ProdId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("ProdId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProductsCategories.Models.ProdCat", b =>
                {
                    b.HasOne("ProductsCategories.Models.Category", "Category")
                        .WithMany("Associations")
                        .HasForeignKey("CatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProductsCategories.Models.Product", "Product")
                        .WithMany("Associations")
                        .HasForeignKey("ProdId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}