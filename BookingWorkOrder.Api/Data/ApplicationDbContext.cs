using BookingWorkOrder.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingWorkOrder.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<WorkOrder> WorkOrders => Set<WorkOrder>();
    public DbSet<WorkOrderLog> WorkOrderLogs => Set<WorkOrderLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.UserName).HasMaxLength(50).IsRequired();
            entity.Property(x => x.PasswordHash).HasMaxLength(255).IsRequired();
            entity.Property(x => x.Role).HasMaxLength(20).IsRequired();
            entity.Property(x => x.Phone).HasMaxLength(20).IsRequired(false);
            entity.Property(x => x.Email).HasMaxLength(100).IsRequired(false);
            entity.Property(x => x.IsActive).IsRequired();
            entity.Property(x => x.CreatedAtUtc).IsRequired();
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.ToTable("Appointments");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.AppointmentTime).IsRequired();
            entity.Property(x => x.ServiceType).HasMaxLength(50).IsRequired();
            entity.Property(x => x.Description).HasMaxLength(500).IsRequired(false);
            entity.Property(x => x.Status).HasConversion<string>().HasMaxLength(20).IsRequired();
            entity.Property(x => x.ReviewNote).HasMaxLength(500).IsRequired(false);
            entity.Property(x => x.CreatedAtUtc).IsRequired();

            entity.HasOne(x => x.User)
                  .WithMany(u => u.Appointments)
                  .HasForeignKey(x => x.UserId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.ReviewedByUser)
                  .WithMany()
                  .HasForeignKey(x => x.ReviewedByUserId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<WorkOrder>(entity =>
        {
            entity.ToTable("WorkOrders");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Title).HasMaxLength(100).IsRequired();
            entity.Property(x => x.Description).HasMaxLength(1000).IsRequired(false);
            entity.Property(x => x.Priority).HasMaxLength(20).IsRequired();
            entity.Property(x => x.Status).HasConversion<string>().HasMaxLength(20).IsRequired();
            entity.Property(x => x.CreatedAtUtc).IsRequired();
            entity.Property(x => x.UpdatedAtUtc).IsRequired(false);

            entity.HasOne(x => x.Appointment)
                  .WithOne(a => a.WorkOrder)
                  .HasForeignKey<WorkOrder>(x => x.AppointmentId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(x => x.AssignedToUser)
                  .WithMany(u => u.AssignedWorkOrders)
                  .HasForeignKey(x => x.AssignedToUserId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<WorkOrderLog>(entity =>
        {
            entity.ToTable("WorkOrderLogs");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Action).HasMaxLength(50).IsRequired();
            entity.Property(x => x.Note).HasMaxLength(1000).IsRequired(false);
            entity.Property(x => x.CreatedAtUtc).IsRequired();

            entity.HasOne(x => x.WorkOrder)
                  .WithMany(w => w.Logs)
                  .HasForeignKey(x => x.WorkOrderId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(x => x.OperatorUser)
                  .WithMany(u => u.WorkOrderLogs)
                  .HasForeignKey(x => x.OperatorUserId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
