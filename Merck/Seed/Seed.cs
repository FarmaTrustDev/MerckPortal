using Microsoft.EntityFrameworkCore;
using Merck.Seed;

namespace Merck.Seed
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            new UserSeeder(modelBuilder);
        }
    }
}
