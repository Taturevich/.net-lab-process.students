using Microsoft.EntityFrameworkCore;

namespace UserCatalogue.Api.Infrastructure
{
    public class UserCatalogueContext : DbContext
    {
        public UserCatalogueContext(DbContextOptions<UserCatalogueContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>()
                .HasKey(pc => new { pc.UserId, pc.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(pc => pc.User)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(pc => pc.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(pc => pc.Role)
                .WithMany(c => c.UserRoles)
                .HasForeignKey(pc => pc.RoleId);

            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Role>().HasKey(u => u.Id);
            modelBuilder.Entity<Role>().Property(u => u.Id).ValueGeneratedOnAdd();
        }
    }
}