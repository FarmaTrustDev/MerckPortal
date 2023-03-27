using Merck.Models;

namespace Merck.Interfaces.Repositories
{
    public interface IUserRoleRepository : IBaseRepository<UserRoles>
    {
        public void DeleteUserRoleByUserId(int userId);
        public UserRoles GetUserRoleByUserId(int userId);

	}
}
