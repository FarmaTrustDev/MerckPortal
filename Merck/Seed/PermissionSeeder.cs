using Merck.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Merck.Seed
{
    public class PermissionSeeder : BaseSeeder
    {
        public PermissionSeeder(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            Up();
        }

        private void Up()
        {
            _modelBuilder.Entity<Permissions>().HasData(LoadData());
        }
        private static List<Permissions> LoadData()
        {
            List<Permissions> permissions = new List<Permissions>();

            permissions.Add(new Permissions()
            {
                Id = 1,
                Name = "View",
                Active = true
            });
            permissions.Add(new Permissions()
            {
                Id = 2,
                Name = "Edit",
                Active = true
            });
            permissions.Add(new Permissions()
            {
                Id = 3,
                Name = "Delete",
                Active = true
            });

            return permissions;
        }
    }
}
