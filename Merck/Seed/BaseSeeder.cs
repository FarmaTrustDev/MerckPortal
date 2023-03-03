using Microsoft.EntityFrameworkCore;

namespace Merck.Seed
{
    public class BaseSeeder
    {
        protected readonly ModelBuilder _modelBuilder;
        public BaseSeeder(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }
    }
}
