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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Seed();
        }
    }
}
