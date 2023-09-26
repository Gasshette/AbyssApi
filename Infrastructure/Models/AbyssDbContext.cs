using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

public partial class AbyssDbContext : DbContext
{
    public AbyssDbContext()
    {
    }

    public AbyssDbContext(DbContextOptions<AbyssDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Deep> Deeps { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=tcp:abyssdbserver.database.windows.net,1433;Initial Catalog=AbyssDB;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication='Active Directory Default';");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");

            entity.HasIndex(e => e.Guid, "IX_Account").IsUnique();

            entity.Property(e => e.Identifier).HasMaxLength(16);
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Deep>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Post");

            entity.ToTable("deep");

            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.Text).HasMaxLength(300);

            entity.HasOne(d => d.Account).WithMany(p => p.Deeps)
                .HasPrincipalKey(p => p.Guid)
                .HasForeignKey(d => d.AccountGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_Account");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
