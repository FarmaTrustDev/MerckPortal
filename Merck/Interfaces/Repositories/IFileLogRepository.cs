using Merck.Models;
using System.Threading.Tasks;

namespace Merck.Interfaces.Repositories
{
    public interface IFileLogRepository : IBaseRepository<FileLog>
    {
        public Task<long?> GetMaxTimestamp();
        public FileLog GetByFileName(string name);
    }
}
