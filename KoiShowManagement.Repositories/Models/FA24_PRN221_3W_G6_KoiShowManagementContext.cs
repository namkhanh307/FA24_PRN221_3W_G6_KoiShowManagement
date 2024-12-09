﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KoiShowManagement.Repositories.Models;

public partial class FA24_PRN221_3W_G6_KoiShowManagementContext : DbContext
{
    public FA24_PRN221_3W_G6_KoiShowManagementContext()
    {
    }

    public FA24_PRN221_3W_G6_KoiShowManagementContext(DbContextOptions<FA24_PRN221_3W_G6_KoiShowManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<AnimalVariety> AnimalVarieties { get; set; }

    public virtual DbSet<Competition> Competitions { get; set; }

    public virtual DbSet<CompetitionCategory> CompetitionCategories { get; set; }

    public virtual DbSet<CompetitionType> CompetitionTypes { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<FinalResult> FinalResults { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PointOnProgressing> PointOnProgressings { get; set; }

    public virtual DbSet<Registration> Registrations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Data Source=NAMKHANH;Initial Catalog=FA24_PRN221_3W_G6_KoiShowManagement;User ID=sa;Password=12345678;TrustServerCertificate=True");
    public static string? GetConnectionString(string connectionStringName)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        string? connectionString = config.GetConnectionString(connectionStringName);
        return connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.AnimalId).HasName("PK__Animals__A21A7307A3484FF4");

            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Variety).WithMany(p => p.Animals)
                .HasForeignKey(d => d.VarietyId)
                .HasConstraintName("FK__Animals__Variety__398D8EEE");
        });

        modelBuilder.Entity<AnimalVariety>(entity =>
        {
            entity.HasKey(e => e.VarietyId).HasName("PK__AnimalVa__08E3A06837441F0D");

            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
        });

        modelBuilder.Entity<Competition>(entity =>
        {
            entity.HasKey(e => e.CompetitionId).HasName("PK__Competit__8F32F4D3B7890D1B");

            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.CompetitionType).WithMany(p => p.Competitions)
                .HasForeignKey(d => d.CompetitionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Competiti__Compe__30F848ED");
        });

        modelBuilder.Entity<CompetitionCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Competit__19093A0B3B3FD225");

            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.JudgingCriteria).HasMaxLength(255);
            entity.Property(e => e.RequiredHealthStatus).HasMaxLength(100);

            entity.HasOne(d => d.Competition).WithMany(p => p.CompetitionCategories)
                .HasForeignKey(d => d.CompetitionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Competiti__Compe__35BCFE0A");

            entity.HasOne(d => d.Variety).WithMany(p => p.CompetitionCategories)
                .HasForeignKey(d => d.VarietyId)
                .HasConstraintName("FK__Competiti__Varie__34C8D9D1");
        });

        modelBuilder.Entity<CompetitionType>(entity =>
        {
            entity.HasKey(e => e.CompetitionTypeId).HasName("PK__Competit__6844B45FBE433BDD");

            entity.ToTable("CompetitionType");

            entity.Property(e => e.CompetitionTypeName).IsRequired();
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDD617E466B2");

            entity.Property(e => e.FeedbackDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FeedbackType).HasMaxLength(50);
            entity.Property(e => e.IsAnonymous).HasDefaultValue(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.IsResponded).HasDefaultValue(false);
            entity.Property(e => e.Platform).HasMaxLength(50);
            entity.Property(e => e.ResponseDate).HasColumnType("datetime");
            entity.Property(e => e.SeverityLevel).HasMaxLength(50);
            entity.Property(e => e.Status).HasDefaultValue(0);
            entity.Property(e => e.VisibilityLevel).HasMaxLength(50);

            entity.HasOne(d => d.Competition).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CompetitionId)
                .HasConstraintName("FK__Feedbacks__Compe__5441852A");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Feedbacks__UserI__5535A963");
        });

        modelBuilder.Entity<FinalResult>(entity =>
        {
            entity.HasKey(e => e.CompetitionResultId).HasName("PK__FinalRes__4B2A041751A89124");

            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.FinalResults)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__FinalResu__Categ__49C3F6B7");

            entity.HasOne(d => d.Competition).WithMany(p => p.FinalResults)
                .HasForeignKey(d => d.CompetitionId)
                .HasConstraintName("FK__FinalResu__Compe__48CFD27E");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A38A8790D4A");

            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(100);
            entity.Property(e => e.Vatrate).HasColumnName("VATRate");

            entity.HasOne(d => d.Registration).WithMany(p => p.Payments)
                .HasForeignKey(d => d.RegistrationId)
                .HasConstraintName("FK__Payments__Regist__4CA06362");
        });

        modelBuilder.Entity<PointOnProgressing>(entity =>
        {
            entity.HasKey(e => e.PointId).HasName("PK__PointOnP__40A977E1C35F467E");

            entity.ToTable("PointOnProgressing");

            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Category).WithMany(p => p.PointOnProgressings)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__PointOnPr__Categ__44FF419A");

            entity.HasOne(d => d.Jury).WithMany(p => p.PointOnProgressings)
                .HasForeignKey(d => d.JuryId)
                .HasConstraintName("FK__PointOnPr__JuryI__4316F928");

            entity.HasOne(d => d.Registration).WithMany(p => p.PointOnProgressings)
                .HasForeignKey(d => d.RegistrationId)
                .HasConstraintName("FK__PointOnPr__Regis__440B1D61");
        });

        modelBuilder.Entity<Registration>(entity =>
        {
            entity.HasKey(e => e.RegistrationId).HasName("PK__Registra__6EF58810A4BFD010");

            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

            entity.HasOne(d => d.Animal).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("FK__Registrat__Anima__3E52440B");

            entity.HasOne(d => d.Competition).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.CompetitionId)
                .HasConstraintName("FK__Registrat__Compe__3D5E1FD2");

            entity.HasOne(d => d.User).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Registrat__UserI__3F466844");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1AB010FE83");

            entity.Property(e => e.RoleName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C475B706B");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Password).IsRequired();
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Username).IsRequired();

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__RoleId__2D27B809");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}