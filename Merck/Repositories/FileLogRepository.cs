using Merck.Interfaces.Repositories;
using Merck.Models;
using System.Linq;

namespace Merck.Repositories
{
    public class FileLogRepository : BaseRepository<FileLog>, IFileLogRepository
    {
        private readonly MyDbContext _dbContext;
        public FileLogRepository(MyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public long? GetMaxTimestamp()
        {
            var maxTimestamp = _dbContext.FileLog.Select(fl => fl.CreatedOn).DefaultIfEmpty().Max();
            return maxTimestamp == default(long) ? null : maxTimestamp;
        }
        public FileLog GetByFileName(string name)
        {
            return _dbContext.FileLog.Where(f => f.Name == name).FirstOrDefault();
        }
    }
}
