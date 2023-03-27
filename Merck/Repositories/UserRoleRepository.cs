using Merck.Interfaces.Repositories;
using Merck.Models;
using System.Linq;

namespace Merck.Repositories
{
    public class UserRoleRepository : BaseRepository<UserRoles>, IUserRoleRepository
    {
        private readonly MyDbContext _dbContext;
        public UserRoleRepository(MyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
		public void DeleteUserRoleByUserId(int userId)
        {
            UserRoles userRoles = GetUserRoleByUserId(userId);
            userRoles.Active = false;
            _dbContext.Update(userRoles);
		}
		public UserRoles GetUserRoleByUserId(int userId)
		{
            return _dbContext.UserRoles.Where(userRole => userRole.UserId == userId ).FirstOrDefault();
		}

	}
}
