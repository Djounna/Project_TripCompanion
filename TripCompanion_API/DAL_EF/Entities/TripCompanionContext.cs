﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL_EF.Entities
{
    public partial class TripCompanionContext : DbContext
    {
        public TripCompanionContext()
        {
        }

        public TripCompanionContext(DbContextOptions<TripCompanionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AttachmentStep> AttachmentSteps { get; set; }
        public virtual DbSet<AttachmentTodo> AttachmentTodos { get; set; }
        public virtual DbSet<AttachmentTrip> AttachmentTrips { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Step> Steps { get; set; }
        public virtual DbSet<Todo> Todos { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AttachmentStep>(entity =>
            {
                entity.HasKey(e => e.IdAttachment);

                entity.ToTable("AttachmentStep");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdStepNavigation)
                    .WithMany(p => p.AttachmentSteps)
                    .HasForeignKey(d => d.IdStep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AttachementStep__Step");
            });

            modelBuilder.Entity<AttachmentTodo>(entity =>
            {
                entity.HasKey(e => e.IdAttachment);

                entity.ToTable("AttachmentTodo");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdTodoNavigation)
                    .WithMany(p => p.AttachmentTodos)
                    .HasForeignKey(d => d.IdTodo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AttachmentTodo__Todo");
            });

            modelBuilder.Entity<AttachmentTrip>(entity =>
            {
                entity.HasKey(e => e.IdAttachment);

                entity.ToTable("AttachmentTrip");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdTripNavigation)
                    .WithMany(p => p.AttachmentTrips)
                    .HasForeignKey(d => d.IdTrip)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AttachmentTrip__Trip");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole);

                entity.ToTable("Role");

                entity.HasIndex(e => e.RoleName, "UK_RoleName")
                    .IsUnique();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Step>(entity =>
            {
                entity.HasKey(e => e.IdStep);

                entity.ToTable("Step");

                entity.Property(e => e.Comments).HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Time).HasColumnType("decimal(4, 2)");

                entity.HasOne(d => d.IdTripNavigation)
                    .WithMany(p => p.Steps)
                    .HasForeignKey(d => d.IdTrip)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Step__IdTrip");
            });

            modelBuilder.Entity<Todo>(entity =>
            {
                entity.HasKey(e => e.IdTodo);

                entity.ToTable("Todo");

                entity.Property(e => e.Calendar).HasColumnType("datetime");

                entity.Property(e => e.Comments).HasColumnType("text");

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PlannedTime).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.Priority).HasMaxLength(50);

                entity.Property(e => e.RealTime).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.HasOne(d => d.IdMainTodoNavigation)
                    .WithMany(p => p.InverseIdMainTodoNavigation)
                    .HasForeignKey(d => d.IdMainTodo)
                    .HasConstraintName("PK_Todo__IdMainTodo");

                entity.HasOne(d => d.IdStepNavigation)
                    .WithMany(p => p.Todos)
                    .HasForeignKey(d => d.IdStep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_Todo__IdStep");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasKey(e => e.IdTrip);

                entity.ToTable("Trip");

                entity.Property(e => e.Comments).HasColumnType("text");

                entity.Property(e => e.EndingDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartingDate).HasColumnType("date");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trip__IdUser");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("User");

                entity.HasIndex(e => e.Email, "UK_Email")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UK_Username")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}