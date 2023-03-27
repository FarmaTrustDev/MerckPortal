using Merck.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Merck.Seed
{
    public class RoleSeeder : BaseSeeder
    {
        public RoleSeeder(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            Up();
        }

        private void Up()
        {
            _modelBuilder.Entity<Roles>().HasData(LoadData());
        }
        private static List<Roles> LoadData()
        {
            List<Roles> roles = new List<Roles>();

            roles.Add(new Roles()
            {
                Id = 1,
                Name = "Admin",
                Active = true
            });

            roles.Add(new Roles()
            {
                Id = 2,
                Name = "Patient",
                Active = true
            });

            return roles;
        }
    }
}
