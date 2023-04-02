using Merck.Models;
using Merck.Seed;
using Microsoft.EntityFrameworkCore;

namespace Merck.Repositories
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<TreatmentEvent> TreatmentEvent { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<PermissionRoles> PermissionRoles { get; set; }
        public DbSet<FileLog> FileLog { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Seed();
        }
    }
}
