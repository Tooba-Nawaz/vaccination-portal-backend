﻿//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;

//namespace Vaccination_Portal_Backend.Models;

//public partial class SvpContext : DbContext
//{
//    public SvpContext()
//    {
//    }

//    public SvpContext(DbContextOptions<SvpContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<StudentsTbl> StudentsTbls { get; set; }

//    public virtual DbSet<VaccinationDriveTbl> VaccinationDriveTbls { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-2VM068K\\SQLEXPRESS;Database=SVP;Trusted_Connection=True;TrustServerCertificate=True;");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<StudentsTbl>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Students__32C52B990EE31261");

//            entity.ToTable("StudentsTbl");

//            entity.Property(e => e.ClassName)
//                .HasMaxLength(50)
//                .IsUnicode(false);
//            entity.Property(e => e.ContactNumber)
//                .HasMaxLength(20)
//                .IsUnicode(false);
//            entity.Property(e => e.Gender)
//                .HasMaxLength(10)
//                .IsUnicode(false);
//            entity.Property(e => e.MedicalNote).HasColumnType("text");
//            entity.Property(e => e.Student)
//                .HasMaxLength(100)
//                .IsUnicode(false);
//            entity.Property(e => e.ParentName)
//                .HasMaxLength(100)
//                .IsUnicode(false);
//            entity.Property(e => e.StudentId)
//                .HasMaxLength(10)
//                .IsFixedLength();
//            entity.Property(e => e.VaccineType)
//                .HasMaxLength(50)
//                .IsUnicode(false);
//        });

//        modelBuilder.Entity<VaccinationDriveTbl>(entity =>
//        {
//            entity.HasKey(e => e.VaccineId).HasName("PK__Vaccinat__45DC6889C5F1581E");

//            entity.ToTable("VaccinationDriveTbl");

//            entity.Property(e => e.Description).HasMaxLength(500);
//            entity.Property(e => e.Location).HasMaxLength(200);
//            entity.Property(e => e.VaccineName).HasMaxLength(100);
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}