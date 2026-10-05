using HospitalManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace HospitalManager.DAL;

public partial class DoAnThietKe1Context : DbContext
{
    public DoAnThietKe1Context()
    {
    }

    public DoAnThietKe1Context(DbContextOptions<DoAnThietKe1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<BacSi> BacSis { get; set; }

    public virtual DbSet<BenhNhan> BenhNhans { get; set; }

    public virtual DbSet<KhoaBenh> KhoaBenhs { get; set; }

    public virtual DbSet<PhieuKhamBenh> PhieuKhamBenhs { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(GetConnectionString());
    }

    private string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
        var strConn = config["ConnectionStrings:DefaultConnectionStringDB"];

        return strConn;
    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BacSi>(entity =>
        {
            entity.HasKey(e => e.MaBacSi).HasName("PK__BacSi__E022715EA88FC3AC");

            entity.ToTable("BacSi");

            entity.Property(e => e.MaBacSi)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.ChucVu).HasMaxLength(30);
            entity.Property(e => e.GioiTinh).HasMaxLength(3);
            entity.Property(e => e.MaKhoa)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NamSinh)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TenBacSi).HasMaxLength(50);

            entity.HasOne(d => d.MaKhoaNavigation).WithMany(p => p.BacSis)
                .HasForeignKey(d => d.MaKhoa)
                .HasConstraintName("FK__BacSi__MaKhoa__4E88ABD4");
        });

        modelBuilder.Entity<BenhNhan>(entity =>
        {
            entity.HasKey(e => e.MaBenhNhan).HasName("PK__BenhNhan__22A8B3304577B81F");

            entity.ToTable("BenhNhan");

            entity.Property(e => e.MaBenhNhan)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.DiaChi).HasMaxLength(60);
            entity.Property(e => e.GioiTinh).HasMaxLength(3);
            entity.Property(e => e.NamSinh)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TenBenhNhan).HasMaxLength(50);
        });

        modelBuilder.Entity<KhoaBenh>(entity =>
        {
            entity.HasKey(e => e.MaKhoa).HasName("PK__KhoaBenh__653904051B5CB5EE");

            entity.ToTable("KhoaBenh");

            entity.Property(e => e.MaKhoa)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DiaChiKhoa).HasMaxLength(50);
            entity.Property(e => e.TenKhoa).HasMaxLength(40);
        });

        modelBuilder.Entity<PhieuKhamBenh>(entity =>
        {

            entity.HasKey(e => e.MaPhieu).HasName("PK__PhieuKha__2660BFE06859BEEA");

            entity.ToTable("PhieuKhamBenh");

            entity.Property(e => e.MaPhieu).ValueGeneratedOnAdd();

            entity.Property(e => e.BacSi).HasMaxLength(50);
            entity.Property(e => e.Buoi).HasMaxLength(5);
            entity.Property(e => e.KetQua).HasMaxLength(100);
            entity.Property(e => e.TenKhoa).HasMaxLength(40);
            entity.Property(e => e.MaBenhNhan)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.NgayKham)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.TrieuChung).HasMaxLength(50);

            entity.HasOne(d => d.MaBenhNhanNavigation).WithMany()
                .HasForeignKey(d => d.MaBenhNhan)
                .HasConstraintName("FK__PhieuKham__MaBen__6FE99F9F");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.TaiKhoanId).HasName("PK__TaiKhoan__9A124B6548578C4B");

            entity.ToTable("TaiKhoan");

            entity.HasIndex(e => e.EmailAddress, "UQ__TaiKhoan__49A14740D2D16BFF").IsUnique();

            entity.Property(e => e.TaiKhoanId)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("TaiKhoanID");
            entity.Property(e => e.EmailAddress).HasMaxLength(60);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.MatKhau).HasMaxLength(40);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
