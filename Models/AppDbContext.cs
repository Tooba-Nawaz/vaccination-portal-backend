using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Vaccination_Portal_Backend.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StudentsTbl> StudentsTbl { get; set; }

    public virtual DbSet<VaccinationDriveTbl> VaccinationDriveTbl { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=TOOBA;Database=vaccinationportaltooba;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VaccinationDriveTbl>(entity =>
        {
            entity.HasKey(e => e.VaccineId).HasName("PK__vaccination_table");

            entity.ToTable("VaccinationDriveTbl");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.VaccineName).HasMaxLength(100);
        });
        modelBuilder.Entity<StudentsTbl>(entity =>
        {
            entity.ToTable("StudentsTbl");

            entity.Property(e => e.Id)
                .HasColumnName("id");

            entity.Property(e => e.Student)
                .HasMaxLength(50)
                .HasColumnName("student");


            entity.Property(e => e.ClassName)
                .HasColumnName("className");



            entity.Property(e => e.Age)
                .HasColumnName("age");



            entity.Property(e => e.VaccinationStatus)
                .HasColumnName("vaccinationStatus")
                .HasMaxLength(50);

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
