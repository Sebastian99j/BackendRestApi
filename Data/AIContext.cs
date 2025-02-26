using System;
using System.Collections.Generic;
using BackendRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendRestApi.Data;

public partial class AIContext : DbContext
{
    public AIContext()
    {
    }

    public AIContext(DbContextOptions<AIContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Authentication> Authentication { get; set; }

    public virtual DbSet<TrainingSeries> TrainingSeries { get; set; }

    public virtual DbSet<TrainingType> TrainingType { get; set; }

    public virtual DbSet<User> User { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.,1444;Database=AI_database;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Authentication>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__authenti__3213E83FF71C1804");

            entity.HasIndex(e => e.username, "UQ__authenti__F3DBC57294AC2EFC").IsUnique();

            entity.Property(e => e.password_hash)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.username)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TrainingSeries>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Training__3214EC073A84DB1F");

            entity.Property(e => e.Trained).HasDefaultValue(false);

            entity.HasOne(d => d.TrainingType).WithMany(p => p.TrainingSeries)
                .HasForeignKey(d => d.TrainingTypeId)
                .HasConstraintName("FK__TrainingS__Train__619B8048");

            entity.HasOne(d => d.User).WithMany(p => p.TrainingSeries)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__TrainingS__UserI__628FA481");
        });

        modelBuilder.Entity<TrainingType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Training__3214EC073AAC948B");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC07527B3376");

            entity.Property(e => e.Ai_Identifier).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(70);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
