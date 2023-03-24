using Merck.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Merck.Seed
{
    public class UserRoleSeeder : BaseSeeder
    {
        public UserRoleSeeder(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            Up();
        }

        private void Up()
        {
            _modelBuilder.Entity<UserRoles>().HasData(LoadData());
        }
        private static List<UserRoles> LoadData()
        {
            List<UserRoles> userRoles = new List<UserRoles>();
            userRoles.Add(new UserRoles()
            {
                Id = 1,
                UserId = 1,
                RoleId = 2,
                Active = true
            });
            userRoles.Add(new UserRoles()
            {
                Id = 2,
                UserId = 2,
                RoleId = 2,
                Active = true
            });
            
            userRoles.Add(new UserRoles()
            {
                Id = 3,
                UserId = 3,
                RoleId = 1,
                Active = true
            });
            
            return userRoles;
        }
    }
}
