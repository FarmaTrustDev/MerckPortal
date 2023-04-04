using Merck.Interfaces.Repositories;
using Merck.Models;

namespace Merck.Repositories
{
    public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
    {
        private readonly MyDbContext _dbContext;
        public DocumentRepository(MyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
