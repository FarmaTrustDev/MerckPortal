using Merck.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Merck.Seed
{
    public class UserSeeder: BaseSeeder
    {
        public UserSeeder(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            Up();
        }

        private void Up()
        {
            _modelBuilder.Entity<User>().HasData(LoadData());
        }
        private static List<User> LoadData()
        {
            List<User> users = new List<User>();

            users.Add(new User()
            {
                Id = 1,
                FirstName = "User",
                LastName = "Ahmed",
                UserName = "AhmedHassan",
                Password = "sf/WPJ/YEvZZrFchRMF92A==", // test123
                Email = "ahmed@gmail.com",
                Active = true
            });

            users.Add(new User()
            {
                Id = 2,
                FirstName = "Paige",
                LastName = "Turner",
                UserName = "PaigeTurner",
                Password = "sf/WPJ/YEvZZrFchRMF92A==", // test123
                Email = "paige@loop.com",
                Active = true
            });

            users.Add(new User()
            {
                Id = 3,
                FirstName = "Raja",
                LastName = "Sharif",
                UserName = "RajaSharif",
                Password = "sf/WPJ/YEvZZrFchRMF92A==", // test123
                Email = "raja@loop.com",
                Active = true
            });
            return users;
        }
    }
}
