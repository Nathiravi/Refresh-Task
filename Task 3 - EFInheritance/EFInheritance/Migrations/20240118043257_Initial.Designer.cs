﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFInheritance.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240118043257_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFInheritance.Models.Person", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("People");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EFInheritance.Models.Student", b =>
                {
                    b.HasBaseType("EFInheritance.Models.Person");

                    b.Property<string>("Section")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("classs")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("EFInheritance.Models.Teacher", b =>
                {
                    b.HasBaseType("EFInheritance.Models.Person");

                    b.Property<int>("Salaray")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
