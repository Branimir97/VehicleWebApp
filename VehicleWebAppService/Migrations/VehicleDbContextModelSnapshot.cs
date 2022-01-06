﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleWebAppService.DAL;

#nullable disable

namespace VehicleWebAppService.Migrations
{
    [DbContext(typeof(VehicleDbContext))]
    partial class VehicleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VehicleWebAppService.Models.VehicleMake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Abrv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleMakes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abrv = "BMW",
                            Name = "BMW"
                        },
                        new
                        {
                            Id = 2,
                            Abrv = "Ford",
                            Name = "Ford"
                        },
                        new
                        {
                            Id = 3,
                            Abrv = "Audi",
                            Name = "Audi"
                        },
                        new
                        {
                            Id = 4,
                            Abrv = "Porsche",
                            Name = "Porsche"
                        },
                        new
                        {
                            Id = 5,
                            Abrv = "Fiat",
                            Name = "Fiat"
                        },
                        new
                        {
                            Id = 6,
                            Abrv = "BMW",
                            Name = "BMW"
                        },
                        new
                        {
                            Id = 7,
                            Abrv = "VW",
                            Name = "Volkswagen"
                        },
                        new
                        {
                            Id = 8,
                            Abrv = "VW",
                            Name = "Volkswagen"
                        },
                        new
                        {
                            Id = 9,
                            Abrv = "Opel",
                            Name = "Opel"
                        },
                        new
                        {
                            Id = 10,
                            Abrv = "GM",
                            Name = "General Motors"
                        });
                });

            modelBuilder.Entity("VehicleWebAppService.Models.VehicleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Abrv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleMakeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleMakeId");

                    b.ToTable("VehicleModels");
                });

            modelBuilder.Entity("VehicleWebAppService.Models.VehicleModel", b =>
                {
                    b.HasOne("VehicleWebAppService.Models.VehicleMake", "VehicleMake")
                        .WithMany("VehicleModels")
                        .HasForeignKey("VehicleMakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleMake");
                });

            modelBuilder.Entity("VehicleWebAppService.Models.VehicleMake", b =>
                {
                    b.Navigation("VehicleModels");
                });
#pragma warning restore 612, 618
        }
    }
}
