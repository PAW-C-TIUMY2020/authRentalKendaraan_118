﻿using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RentalKendaraan_NIM.Models
{
    public partial class Rent_KendaraanContext : IdentityDbContext
    {
        public Rent_KendaraanContext()
        {
        }

        public Rent_KendaraanContext(DbContextOptions<Rent_KendaraanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Jaminan> Jaminan { get; set; }
        public virtual DbSet<JenisKendaraan> JenisKendaraan { get; set; }
        public virtual DbSet<Kendaraan> Kendaraan { get; set; }
        public virtual DbSet<KondisiKendaraan> KondisiKendaraan { get; set; }
        public virtual DbSet<Peminjaman> Peminjaman { get; set; }
        public virtual DbSet<Pengembalian> Pengembalian { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-EJH2D6F\\ARYA;User ID=sa;Password=arya@cool123;Database=Rent_Kendaraan;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdGender).HasColumnName("ID_Gender");

                entity.Property(e => e.NamaCustomer)
                    .HasColumnName("Nama_Customer")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nik)
                    .HasColumnName("NIK")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.NoHp)
                    .HasColumnName("No_HP")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGenderNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.IdGender)
                    .HasConstraintName("FK_Customer_Gender1");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.IdGender);

                entity.Property(e => e.IdGender).HasColumnName("ID_Gender");

                entity.Property(e => e.NamaGender)
                    .HasColumnName("Nama_Gender")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Jaminan>(entity =>
            {
                entity.HasKey(e => e.IdJaminan);

                entity.Property(e => e.IdJaminan).HasColumnName("ID_Jaminan");

                entity.Property(e => e.NamaJaminan)
                    .HasColumnName("Nama_Jaminan")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JenisKendaraan>(entity =>
            {
                entity.HasKey(e => e.IdJenisKendaraan);

                entity.ToTable("Jenis_Kendaraan");

                entity.Property(e => e.IdJenisKendaraan).HasColumnName("ID_Jenis_Kendaraan");

                entity.Property(e => e.NamaJenisKendaraan)
                    .HasColumnName("Nama_Jenis_Kendaraan")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kendaraan>(entity =>
            {
                entity.HasKey(e => e.IdKendaraan);

                entity.Property(e => e.IdKendaraan).HasColumnName("ID_Kendaraan");

                entity.Property(e => e.IdJenisKendaraan).HasColumnName("ID_Jenis_Kendaraan");

                entity.Property(e => e.Ketersediaan)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NamaKendaraan)
                    .HasColumnName("Nama_Kendaraan")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.NoPolisi)
                    .HasColumnName("No_Polisi")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NoStnk)
                    .HasColumnName("NO_STNK")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdJenisKendaraanNavigation)
                    .WithMany(p => p.Kendaraan)
                    .HasForeignKey(d => d.IdJenisKendaraan)
                    .HasConstraintName("FK_Kendaraan_Jenis_Kendaraan1");
            });

            modelBuilder.Entity<KondisiKendaraan>(entity =>
            {
                entity.HasKey(e => e.IdKondisi);

                entity.ToTable("Kondisi_Kendaraan");

                entity.Property(e => e.IdKondisi).HasColumnName("ID_Kondisi");

                entity.Property(e => e.NamaKondisi)
                    .HasColumnName("Nama_Kondisi")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Peminjaman>(entity =>
            {
                entity.HasKey(e => e.IdPeminjaman);

                entity.Property(e => e.IdPeminjaman).HasColumnName("ID_Peminjaman");

                entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");

                entity.Property(e => e.IdJaminan).HasColumnName("ID_Jaminan");

                entity.Property(e => e.IdKendaraan).HasColumnName("ID_Kendaraan");

                entity.Property(e => e.TglPeminjaman)
                    .HasColumnName("Tgl_Peminjaman")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Peminjaman)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK_Peminjaman_Customer");

                entity.HasOne(d => d.IdJaminanNavigation)
                    .WithMany(p => p.Peminjaman)
                    .HasForeignKey(d => d.IdJaminan)
                    .HasConstraintName("FK_Peminjaman_Jaminan");

                entity.HasOne(d => d.IdKendaraanNavigation)
                    .WithMany(p => p.Peminjaman)
                    .HasForeignKey(d => d.IdKendaraan)
                    .HasConstraintName("FK_Peminjaman_Kendaraan1");
            });

            modelBuilder.Entity<Pengembalian>(entity =>
            {
                entity.HasKey(e => e.IdPengembalian);

                entity.Property(e => e.IdPengembalian).HasColumnName("ID_Pengembalian");

                entity.Property(e => e.IdKondisi).HasColumnName("ID_Kondisi");

                entity.Property(e => e.IdPeminjaman).HasColumnName("ID_Peminjaman");

                entity.Property(e => e.TglPengembalian)
                    .HasColumnName("Tgl_Pengembalian")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdKondisiNavigation)
                    .WithMany(p => p.Pengembalian)
                    .HasForeignKey(d => d.IdKondisi)
                    .HasConstraintName("FK_Pengembalian_Kondisi_Kendaraan");

                entity.HasOne(d => d.IdPeminjamanNavigation)
                    .WithMany(p => p.Pengembalian)
                    .HasForeignKey(d => d.IdPeminjaman)
                    .HasConstraintName("FK_Pengembalian_Peminjaman");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
