using Microsoft.EntityFrameworkCore;
using TaskManagementProject.Domain.Entities;

namespace TaskManagementProject.Data.Context;

public partial class TaskManagementProjectContext : DbContext
{
    public TaskManagementProjectContext()
    {
    }

    public TaskManagementProjectContext(DbContextOptions<TaskManagementProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<t_Task> Tasks { get; set; }

    public virtual DbSet<t_User> TUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-4LVESM3;Database=TaskProject;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<t_Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Task");

            entity.ToTable("t_Tasks");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<t_User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_t_User");
            entity.ToTable("t_User");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .IsFixedLength();
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
