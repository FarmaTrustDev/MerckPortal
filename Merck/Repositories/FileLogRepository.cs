using Merck.Interfaces.Repositories;
using Merck.Models;

namespace Merck.Repositories
{
    public class FileLogRepository : BaseRepository<FileLog>, IFileLogRepository
    {
        private readonly MyDbContext _dbContext;
        public FileLogRepository(MyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
