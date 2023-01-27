using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaskProject
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Journal> Journals { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<Tour> Tours { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(DB.CONNECTION, DB.Version);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("PRIMARY");

                entity.ToTable("client");

                entity.Property(e => e.FullName).HasColumnType("text");

                entity.Property(e => e.Phone).HasMaxLength(11);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.IdCity)
                    .HasName("PRIMARY");

                entity.ToTable("country");

                entity.Property(e => e.Name).HasColumnType("text");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("PRIMARY");

                entity.ToTable("employee");

                entity.Property(e => e.FullName).HasColumnType("text");

                entity.Property(e => e.Login).HasColumnType("text");

                entity.Property(e => e.Password).HasColumnType("text");

                entity.Property(e => e.Phone).HasMaxLength(11);

                entity.Property(e => e.Status).HasColumnType("enum('Работает','Уволен')");
            });

            modelBuilder.Entity<Journal>(entity =>
            {
                entity.HasKey(e => e.IdRecord)
                    .HasName("PRIMARY");

                entity.ToTable("journal");

                entity.HasIndex(e => e.ClientId, "ClientId_idx");

                entity.HasIndex(e => e.TourId, "TourId_idx");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Journals)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ClientId");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.Journals)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TourId");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.IdRecord)
                    .HasName("PRIMARY");

                entity.ToTable("log");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.EmployeeFullName).HasColumnType("text");
            });

            modelBuilder.Entity<Tour>(entity =>
            {
                entity.HasKey(e => e.IdTour)
                    .HasName("PRIMARY");

                entity.ToTable("tour");

                entity.HasIndex(e => e.IdCity, "IdCity_idx");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.HasOne(d => d.IdCityNavigation)
                    .WithMany(p => p.Tours)
                    .HasForeignKey(d => d.IdCity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdCity");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
