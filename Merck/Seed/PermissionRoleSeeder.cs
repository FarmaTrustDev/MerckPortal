using Merck.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Merck.Seed
{
    public class PermissionRoleSeeder : BaseSeeder
    {
        public PermissionRoleSeeder(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            Up();
        }

        private void Up()
        {
            _modelBuilder.Entity<PermissionRoles>().HasData(LoadData());
        }
        private static List<PermissionRoles> LoadData()
        {
            List<PermissionRoles> permissionRoles = new List<PermissionRoles>();
            permissionRoles.Add(new PermissionRoles()
            {
                Id = 1,
                RoleId = 1,
                PermissionId = 1,
                Active = true
            });
            permissionRoles.Add(new PermissionRoles()
            {
                Id = 2,
                RoleId = 1,
                PermissionId = 2,
                Active = true
            });
            permissionRoles.Add(new PermissionRoles()
            {
                Id = 3,
                RoleId = 1,
                PermissionId = 3,
                Active = true
            });
            permissionRoles.Add(new PermissionRoles()
            {
                Id = 4,
                RoleId = 2,
                PermissionId = 1,
                Active = true
            });

            return permissionRoles;
        }
    }
}
