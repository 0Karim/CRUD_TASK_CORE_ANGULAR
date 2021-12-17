﻿// <auto-generated />
using System;
using CleanArch.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanArch.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211217140241_InitMigration")]
    partial class InitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("CleanArch.Domain.Entities.AddressInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BuildingNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("GovId")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("GovId");

                    b.ToTable("AddressInfo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BuildingNumber = "19",
                            CityId = 1,
                            GovId = 1,
                            Street = "9"
                        },
                        new
                        {
                            Id = 2,
                            BuildingNumber = "19",
                            CityId = 2,
                            GovId = 2,
                            Street = "9"
                        },
                        new
                        {
                            Id = 3,
                            BuildingNumber = "12",
                            CityId = 3,
                            GovId = 3,
                            Street = "9"
                        },
                        new
                        {
                            Id = 4,
                            BuildingNumber = "9",
                            CityId = 1,
                            GovId = 1,
                            Street = "9"
                        });
                });

            modelBuilder.Entity("CleanArch.Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("City");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityName = "Cairo"
                        },
                        new
                        {
                            Id = 2,
                            CityName = "Alex"
                        },
                        new
                        {
                            Id = 3,
                            CityName = "Assuit"
                        });
                });

            modelBuilder.Entity("CleanArch.Domain.Entities.Governate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("GovName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Governate");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GovName = "Egypt"
                        },
                        new
                        {
                            Id = 2,
                            GovName = "Saudi"
                        },
                        new
                        {
                            Id = 3,
                            GovName = "France"
                        });
                });

            modelBuilder.Entity("CleanArch.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            BirthDate = new DateTime(1996, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "karimalaa@test.com",
                            FirstName = "Karim",
                            IsDeleted = false,
                            LastName = "Sayed",
                            MiddleName = "Alaa",
                            MobileNumber = "0101123405940"
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 1,
                            BirthDate = new DateTime(1996, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "karimalaa@test.com",
                            FirstName = "Karim",
                            IsDeleted = false,
                            LastName = "Sayed",
                            MiddleName = "Alaa",
                            MobileNumber = "0101123405940"
                        },
                        new
                        {
                            Id = 3,
                            AddressId = 1,
                            BirthDate = new DateTime(1996, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "karimalaa@test.com",
                            FirstName = "Nour",
                            IsDeleted = false,
                            LastName = "Sayed",
                            MiddleName = "Alaa",
                            MobileNumber = "0101123405940"
                        },
                        new
                        {
                            Id = 4,
                            AddressId = 1,
                            BirthDate = new DateTime(1996, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "karimalaa@test.com",
                            FirstName = "Sondos",
                            IsDeleted = false,
                            LastName = "Sayed",
                            MiddleName = "Alaa",
                            MobileNumber = "0101123405940"
                        },
                        new
                        {
                            Id = 5,
                            AddressId = 1,
                            BirthDate = new DateTime(1996, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "karimalaa@test.com",
                            FirstName = "Wael",
                            IsDeleted = false,
                            LastName = "Sayed",
                            MiddleName = "Alaa",
                            MobileNumber = "0101123405940"
                        },
                        new
                        {
                            Id = 6,
                            AddressId = 1,
                            BirthDate = new DateTime(1996, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "karimalaa@test.com",
                            FirstName = "Ehab",
                            IsDeleted = false,
                            LastName = "Sayed",
                            MiddleName = "Alaa",
                            MobileNumber = "0101123405940"
                        });
                });

            modelBuilder.Entity("CleanArch.Domain.Entities.AddressInfo", b =>
                {
                    b.HasOne("CleanArch.Domain.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanArch.Domain.Entities.Governate", "Governate")
                        .WithMany()
                        .HasForeignKey("GovId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Governate");
                });

            modelBuilder.Entity("CleanArch.Domain.Entities.User", b =>
                {
                    b.HasOne("CleanArch.Domain.Entities.AddressInfo", "UserAddress")
                        .WithMany("Users")
                        .HasForeignKey("AddressId");

                    b.Navigation("UserAddress");
                });

            modelBuilder.Entity("CleanArch.Domain.Entities.AddressInfo", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}