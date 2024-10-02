﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace lablinAPI.Models;

public partial class lablinContext : DbContext
{
    public lablinContext()
    {
    }

    public lablinContext(DbContextOptions<lablinContext> options)
        : base(options)
    {
    }

    public virtual DbSet<tbl_directories> tbl_directories { get; set; }

    public virtual DbSet<tbl_extraction_kit> tbl_extraction_kit { get; set; }

    public virtual DbSet<tbl_extraction_method> tbl_extraction_method { get; set; }

    public virtual DbSet<tbl_facility> tbl_facility { get; set; }

    public virtual DbSet<tbl_flowcell> tbl_flowcell { get; set; }

    public virtual DbSet<tbl_library_facility> tbl_library_facility { get; set; }

    public virtual DbSet<tbl_ngs_run_info> tbl_ngs_run_info { get; set; }

    public virtual DbSet<tbl_project> tbl_project { get; set; }

    public virtual DbSet<tbl_project_files> tbl_project_files { get; set; }

    public virtual DbSet<tbl_project_properties> tbl_project_properties { get; set; }

    public virtual DbSet<tbl_project_users> tbl_project_users { get; set; }

    public virtual DbSet<tbl_sample> tbl_sample { get; set; }

    public virtual DbSet<tbl_sequencing_facility> tbl_sequencing_facility { get; set; }

    public virtual DbSet<tbl_users> tbl_users { get; set; }

    public virtual DbSet<tec_project_samples> tec_project_samples { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=192.168.10.51;database=lablin;uid=root;pwd=mercedes83", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.39-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<tbl_directories>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.path)
                .IsRequired()
                .HasColumnType("text");
        });

        modelBuilder.Entity<tbl_extraction_kit>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.name).HasColumnType("text");
        });

        modelBuilder.Entity<tbl_extraction_method>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.name).HasColumnType("text");
        });

        modelBuilder.Entity<tbl_facility>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.name).HasColumnType("text");
        });

        modelBuilder.Entity<tbl_flowcell>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.name).HasColumnType("text");
        });

        modelBuilder.Entity<tbl_library_facility>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.name).HasMaxLength(100);
        });

        modelBuilder.Entity<tbl_ngs_run_info>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.runInfo).HasColumnType("text");
        });

        modelBuilder.Entity<tbl_project>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.date_of_submission).HasColumnType("datetime");
            entity.Property(e => e.length).HasMaxLength(100);
            entity.Property(e => e.project_name).HasColumnType("text");
            entity.Property(e => e.project_number).HasColumnType("text");
            entity.Property(e => e.sample_info).HasColumnType("text");
        });

        modelBuilder.Entity<tbl_project_files>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PRIMARY");

            entity.Property(e => e.createdDateTime).HasColumnType("datetime");
            entity.Property(e => e.filePath).HasColumnType("text");
            entity.Property(e => e.fileType).HasColumnType("text");
        });

        modelBuilder.Entity<tbl_project_properties>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");
        });

        modelBuilder.Entity<tbl_project_users>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PRIMARY");
        });

        modelBuilder.Entity<tbl_sample>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.analysis).HasColumnType("text");
            entity.Property(e => e.analysisType).HasColumnType("text");
            entity.Property(e => e.batchDescription).HasColumnType("text");
            entity.Property(e => e.cellType).HasColumnType("text");
            entity.Property(e => e.condition).HasColumnType("text");
            entity.Property(e => e.createdDateTime).HasColumnType("datetime");
            entity.Property(e => e.donorType).HasColumnType("text");
            entity.Property(e => e.experimentalGroup).HasColumnType("text");
            entity.Property(e => e.medGenID).HasColumnType("text");
            entity.Property(e => e.notes).HasColumnType("text");
            entity.Property(e => e.parentalLine).HasColumnType("text");
            entity.Property(e => e.qualityOfLibrary).HasColumnType("text");
            entity.Property(e => e.raw_data).HasColumnType("text");
            entity.Property(e => e.replicateDescription).HasColumnType("text");
            entity.Property(e => e.sampleName).HasColumnType("text");
            entity.Property(e => e.species).HasColumnType("text");
            entity.Property(e => e.technicalReplicateNumber).HasColumnType("text");
        });

        modelBuilder.Entity<tbl_sequencing_facility>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.name).HasMaxLength(100);
        });

        modelBuilder.Entity<tbl_users>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.name).HasColumnType("text");
        });

        modelBuilder.Entity<tec_project_samples>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}