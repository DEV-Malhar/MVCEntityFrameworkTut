using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProLoginFormASPCore.Models;

public partial class MyTestDatabaseContext : DbContext
{
    public MyTestDatabaseContext()
    {
    }

    public MyTestDatabaseContext(DbContextOptions<MyTestDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

   /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer();*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StdId);

            entity.Property(e => e.StudentGender)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.StudentName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblUser__3214EC07674701F9");

            entity.ToTable("tblUser");

            entity.HasIndex(e => e.Email, "UQ__tblUser__A9D105348A983CC9").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
