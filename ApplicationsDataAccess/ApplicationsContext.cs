using System;
using System.Collections.Generic;
using ApplicationsDataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationsDataAccess;

public partial class ApplicationsContext : DbContext
{
    public ApplicationsContext()
    {
    }

    public ApplicationsContext(DbContextOptions<ApplicationsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Interview> Interviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<VCompanyRole> VCompanyRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Applications;Integrated Security=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK_Companies");

            entity.ToTable("COMPANIES");

            entity.HasIndex(e => e.Company1, "U_Company").IsUnique();

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.Applied)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime");
            entity.Property(e => e.City)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.Company1)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("Company");
            entity.Property(e => e.StateAbbr)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.StatusChange)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime");
            entity.Property(e => e.StatusId).HasDefaultValue(1);

            entity.HasOne(d => d.Status).WithMany(p => p.Companies)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Requests_Statuses_StatusID");
        });

        modelBuilder.Entity<Interview>(entity =>
        {
            entity.HasKey(e => e.InterviewId).HasName("PK_Interviews");

            entity.ToTable("INTERVIEWS");

            entity.Property(e => e.Created)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime");
            entity.Property(e => e.InterviewLevel).HasDefaultValue(1);
            entity.Property(e => e.InterviewedWith)
                .HasMaxLength(512)
                .IsUnicode(false);

            entity.HasOne(d => d.Company).WithMany(p => p.Interviews)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Interviews_Companies_CompanyId");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK_Roles");

            entity.ToTable("ROLES");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(512)
                .IsUnicode(false);

            entity.HasOne(d => d.Company).WithMany(p => p.Roles)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Roles_Companies_CompanyId");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK_Statuses");

            entity.ToTable("STATUSES");

            entity.Property(e => e.StatusName)
                .HasMaxLength(128)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VCompanyRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vCompanyRoles");

            entity.Property(e => e.Applied).HasColumnType("datetime");
            entity.Property(e => e.City)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.Company)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.InterviewTime).HasColumnType("datetime");
            entity.Property(e => e.InterviewedWith)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.RoleName)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.Stateabbr)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.StatusChange).HasColumnType("datetime");
            entity.Property(e => e.StatusName)
                .HasMaxLength(128)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
