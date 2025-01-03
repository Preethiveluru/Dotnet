﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplicationApiEF;

#nullable disable

namespace WebApplicationApiEF.Migrations
{
    [DbContext(typeof(PetDBContext))]
    partial class PetDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApplicationApiEF.Models.PetAnimal", b =>
                {
                    b.Property<int>("petId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("petId"));

                    b.Property<bool>("IsVeg")
                        .HasColumnType("boolean");

                    b.Property<string>("petName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("petType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("petId");

                    b.ToTable("petAnimals");
                });
#pragma warning restore 612, 618
        }
    }
}
