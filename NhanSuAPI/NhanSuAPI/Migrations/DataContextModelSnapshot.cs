﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NhanSuAPI.Data;

#nullable disable

namespace NhanSuAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NhanSuAPI.Data.CongViec", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CongViecId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset?>("DeleteDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("TenCongViec")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CongViecId");

                    b.ToTable("CongViecs");
                });

            modelBuilder.Entity("NhanSuAPI.Data.NhanSu", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset?>("DeleteDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("GioiTinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaPhongBan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhongBanId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PhongBanId");

                    b.ToTable("NhanSus");
                });

            modelBuilder.Entity("NhanSuAPI.Data.PhanCong", b =>
                {
                    b.Property<string>("MaNhanSu")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaCongViec")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CongViecId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset?>("DeleteDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("NgayBD")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("NgayKT")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("MaNhanSu", "MaCongViec");

                    b.HasIndex("CongViecId");

                    b.ToTable("PhanCongs");
                });

            modelBuilder.Entity("NhanSuAPI.Data.PhongBan", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset?>("DeleteDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("TenPhongBan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PhongBans");
                });

            modelBuilder.Entity("NhanSuAPI.Data.CongViec", b =>
                {
                    b.HasOne("NhanSuAPI.Data.CongViec", null)
                        .WithMany("CongViecs")
                        .HasForeignKey("CongViecId");
                });

            modelBuilder.Entity("NhanSuAPI.Data.NhanSu", b =>
                {
                    b.HasOne("NhanSuAPI.Data.PhongBan", "PhongBan")
                        .WithMany("NhanSus")
                        .HasForeignKey("PhongBanId");

                    b.Navigation("PhongBan");
                });

            modelBuilder.Entity("NhanSuAPI.Data.PhanCong", b =>
                {
                    b.HasOne("NhanSuAPI.Data.CongViec", "CongViec")
                        .WithMany()
                        .HasForeignKey("CongViecId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NhanSuAPI.Data.NhanSu", "NhanSu")
                        .WithMany("PhanCongs")
                        .HasForeignKey("MaNhanSu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CongViec");

                    b.Navigation("NhanSu");
                });

            modelBuilder.Entity("NhanSuAPI.Data.CongViec", b =>
                {
                    b.Navigation("CongViecs");
                });

            modelBuilder.Entity("NhanSuAPI.Data.NhanSu", b =>
                {
                    b.Navigation("PhanCongs");
                });

            modelBuilder.Entity("NhanSuAPI.Data.PhongBan", b =>
                {
                    b.Navigation("NhanSus");
                });
#pragma warning restore 612, 618
        }
    }
}
