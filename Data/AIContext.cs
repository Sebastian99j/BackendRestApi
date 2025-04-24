using System;
using System.Collections.Generic;
using BackendRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendRestApi.Data;

public class AIContext : DbContext
{
    public AIContext(DbContextOptions<AIContext> options)
        : base(options)
    {
        var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");

        Console.WriteLine($"DATABASE_URL: {connectionString}");

        if (string.IsNullOrEmpty(connectionString))
        {
            Console.WriteLine($"DATABASE_URL: none");
            //throw new InvalidOperationException("❌ ERROR: DATABASE_URL is not set.");
        }
    }

    public virtual DbSet<TrainingSeries> TrainingSeries { get; set; }

    public virtual DbSet<TrainingTypes> TrainingTypes { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.IsConfigured)
    //    {
    //        var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");

    //        // 🔧 Dodaj logowanie connection stringa:
    //        Console.WriteLine($"🔧 DATABASE_URL: {connectionString}");

    //        if (string.IsNullOrEmpty(connectionString))
    //        {
    //            throw new InvalidOperationException("❌ ERROR: DATABASE_URL is not set.");
    //        }

    //        optionsBuilder.UseSqlServer(connectionString);
    //    }
    //}

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Authentication>(entity =>
    //    {
    //        entity.HasKey(e => e.id).HasName("PK__authenti__3213E83FF71C1804");

    //        entity.HasIndex(e => e.username, "UQ__authenti__F3DBC57294AC2EFC").IsUnique();

    //        entity.Property(e => e.password_hash)
    //            .HasMaxLength(128)
    //            .IsUnicode(false);
    //        entity.Property(e => e.username)
    //            .HasMaxLength(80)
    //            .IsUnicode(false);
    //    });

    //    modelBuilder.Entity<TrainingSeries>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK__Training__3214EC073A84DB1F");

    //        entity.Property(e => e.Trained).HasDefaultValue(false);

    //        entity.HasOne(d => d.TrainingType).WithMany(p => p.TrainingSeries)
    //            .HasForeignKey(d => d.TrainingTypeId)
    //            .HasConstraintName("FK__TrainingS__Train__619B8048");

    //        entity.HasOne(d => d.User).WithMany(p => p.TrainingSeries)
    //            .HasForeignKey(d => d.UserId)
    //            .HasConstraintName("FK__TrainingS__UserI__628FA481");
    //    });

    //    modelBuilder.Entity<TrainingType>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK__Training__3214EC073AAC948B");

    //        entity.Property(e => e.Name).HasMaxLength(100);
    //    });

    //    modelBuilder.Entity<User>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK__User__3214EC07527B3376");

    //        entity.Property(e => e.Ai_Identifier).HasMaxLength(100);
    //        entity.Property(e => e.Name).HasMaxLength(70);
    //    });

    //    OnModelCreatingPartial(modelBuilder);
    //}

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
