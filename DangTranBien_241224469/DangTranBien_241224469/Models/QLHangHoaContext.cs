using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DangTranBien_241224469.Models;

public partial class QLHangHoaContext : DbContext
{
    public QLHangHoaContext()
    {
    }

    public QLHangHoaContext(DbContextOptions<QLHangHoaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HangHoa> HangHoas { get; set; }

    public virtual DbSet<LoaiHang> LoaiHangs { get; set; }

    public virtual DbSet<TblAccount> TblAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=QLHangHoa;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HangHoa>(entity =>
        {
            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.HangHoas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HangHoa_LoaiHang");
        });

        modelBuilder.Entity<TblAccount>(entity =>
        {
            entity.Property(e => e.Password).IsFixedLength();
            entity.Property(e => e.Username).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
