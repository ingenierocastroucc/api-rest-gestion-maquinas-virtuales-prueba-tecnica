using Microsoft.EntityFrameworkCore;
using VMManagerAPI.Models;
using VMManagerAPI.Models.Dto;

namespace VMManagerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<VirtualMachine> VirtualMachines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserDto>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.HasIndex(u => u.Email).IsUnique();
                entity.Property(u => u.Email).IsRequired();
                entity.Property(u => u.PasswordHash).IsRequired();
                entity.Property(u => u.Role).IsRequired();
            });

            modelBuilder.Entity<VirtualMachineDto>(entity =>
            {
                entity.HasKey(vm => vm.Id);
                entity.Property(vm => vm.Name).IsRequired();
                entity.Property(vm => vm.OS).IsRequired();
                entity.Property(vm => vm.RAM).IsRequired();
                entity.Property(vm => vm.CPU).IsRequired();
                entity.Property(vm => vm.Disk).IsRequired();
                entity.Property(vm => vm.Status).IsRequired();
                entity.Property(vm => vm.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(vm => vm.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(vm => vm.User)
                      .WithMany()
                      .HasForeignKey(vm => vm.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}