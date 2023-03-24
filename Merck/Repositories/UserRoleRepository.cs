using Merck.Interfaces.Repositories;
using Merck.Models;

namespace Merck.Repositories
{
    public class UserRoleRepository : BaseRepository<UserRoles>, IUserRoleRepository
    {
        private readonly MyDbContext _dbContext;
        public UserRoleRepository(MyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
