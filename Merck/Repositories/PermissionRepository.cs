using Merck.Interfaces.Repositories;
using Merck.Models;

namespace Merck.Repositories
{
    public class PermissionRepository : BaseRepository<Permissions>, IPermissionsRepository
    {
        private readonly MyDbContext _dbContext;
        public PermissionRepository(MyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
