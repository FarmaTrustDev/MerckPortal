﻿// <auto-generated />
using System;
using Merck.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Merck.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Merck.Models.FileLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool?>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("GlobalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Hash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MerckHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Tempered")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FileLog");
                });

            modelBuilder.Entity("Merck.Models.PermissionRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool?>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("GlobalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("PermissionRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            GlobalId = new Guid("5009a0b7-a02d-46f5-9455-6ea0af2d307c"),
                            PermissionId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            GlobalId = new Guid("4a770915-bd24-4e32-b018-81ae7275f256"),
                            PermissionId = 2,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            GlobalId = new Guid("1826be8c-0dd7-4c9b-ad80-d189dc4fd73c"),
                            PermissionId = 3,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 4,
                            Active = true,
                            GlobalId = new Guid("f725faa8-1d44-4b95-a5b6-7570dd03b00d"),
                            PermissionId = 1,
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("Merck.Models.Permissions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool?>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("GlobalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            GlobalId = new Guid("e6fd0b3a-b219-4f9e-93ca-18ce3093f505"),
                            Name = "View"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            GlobalId = new Guid("f9b5bf1a-7302-4f1e-b9d9-84d5807a0488"),
                            Name = "Edit"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            GlobalId = new Guid("a3c65709-2767-4cf8-9425-2810f13b8b12"),
                            Name = "Delete"
                        });
                });

            modelBuilder.Entity("Merck.Models.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool?>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("GlobalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            GlobalId = new Guid("3e74ac23-fb39-4093-9e37-7a72eb988b91"),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            GlobalId = new Guid("8eb98268-18fa-45f6-a390-d12a515dd049"),
                            Name = "Patient"
                        });
                });

            modelBuilder.Entity("Merck.Models.TreatmentEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool?>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeviceSerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Event")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("GlobalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Hash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecordType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransmissionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TransmissionTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("TreatmentEvent");
                });

            modelBuilder.Entity("Merck.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool?>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("DOB")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(40)");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<Guid?>("GlobalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            Email = "ahmed@gmail.com",
                            FirstName = "Ahmed",
                            Gender = (byte)0,
                            GlobalId = new Guid("b82ae696-189d-4754-ab37-bee0c72caf50"),
                            LastName = "Hassan",
                            Password = "sf/WPJ/YEvZZrFchRMF92A==",
                            UserName = "AhmedHassan"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            Email = "paige@loop.com",
                            FirstName = "Paige",
                            Gender = (byte)0,
                            GlobalId = new Guid("75b41506-a41a-421b-839e-c9dacfe4cc9c"),
                            LastName = "Turner",
                            Password = "sf/WPJ/YEvZZrFchRMF92A==",
                            UserName = "PaigeTurner"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            Email = "raja@loop.com",
                            FirstName = "Raja",
                            Gender = (byte)0,
                            GlobalId = new Guid("54ddd15e-c659-4cc6-a360-2193fd769d22"),
                            LastName = "Sharif",
                            Password = "sf/WPJ/YEvZZrFchRMF92A==",
                            UserName = "RajaSharif"
                        });
                });

            modelBuilder.Entity("Merck.Models.UserRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool?>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("GlobalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            GlobalId = new Guid("29a603ec-b389-40d7-beff-337b77b0a34a"),
                            RoleId = 2,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            GlobalId = new Guid("66d2e65c-7531-41f3-a70c-181ef9295ea5"),
                            RoleId = 2,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            GlobalId = new Guid("394e112b-a093-46df-8216-9cc4c4bfe812"),
                            RoleId = 1,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Merck.Models.PermissionRoles", b =>
                {
                    b.HasOne("Merck.Models.Permissions", "Permission")
                        .WithMany("PermissionRoles")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Merck.Models.Roles", "Role")
                        .WithMany("PermissionRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Merck.Models.UserRoles", b =>
                {
                    b.HasOne("Merck.Models.Roles", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Merck.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Merck.Models.Permissions", b =>
                {
                    b.Navigation("PermissionRoles");
                });

            modelBuilder.Entity("Merck.Models.Roles", b =>
                {
                    b.Navigation("PermissionRoles");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Merck.Models.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
