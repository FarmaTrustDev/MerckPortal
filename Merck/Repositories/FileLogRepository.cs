using Merck.Interfaces.Repositories;
using Merck.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Merck.Repositories
{
    public class FileLogRepository : BaseRepository<FileLog>, IFileLogRepository
    {
        private readonly MyDbContext _dbContext;
        public FileLogRepository(MyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<long?> GetMaxTimestamp()
        {
            var maxTimestamp = await _dbContext.FileLog.Select(fl => fl.CreatedOn).DefaultIfEmpty().MaxAsync();
            return maxTimestamp == default(long) ? null : maxTimestamp;
        }
        public FileLog GetByFileName(string name)
        {
            return _dbContext.FileLog.Where(f => f.Name == name).FirstOrDefault();
        }
    }
}
