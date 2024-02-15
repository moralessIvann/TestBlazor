using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestBlazor.ServerAPI.Models;

public partial class DbtestBlazorContext : DbContext
{
    public DbtestBlazorContext()
    {
    }

    public DbtestBlazorContext(DbContextOptions<DbtestBlazorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmployee).HasName("PK__employee__227F26A57BE74BC4");

            entity.ToTable("employee");

            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.ContractDate)
                .HasColumnType("date")
                .HasColumnName("contractDate");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fullName");
            entity.Property(e => e.Income).HasColumnName("income");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
