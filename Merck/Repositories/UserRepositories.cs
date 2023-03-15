
using Merck.Interfaces.Repositories;
using Merck.Models;

namespace Merck.Repositories
{
    public class UserRepositories: BaseRepository<User>, IUserRepositories
    {
        private readonly MyDbContext _dbContext;
        public UserRepositories(MyDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
