using Merck.Models;

namespace Merck.Interfaces.Repositories
{
    public interface IFileLogRepository : IBaseRepository<FileLog>
    {
        public long? GetMaxTimestamp();
        public FileLog GetByFileName(string name);
    }
}
