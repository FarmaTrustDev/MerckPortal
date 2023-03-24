using Merck.Interfaces.Repositories;
using Merck.Models;
using System.Collections.Generic;

namespace Merck.Services
{
    public class UserRoleServices
    {
        private readonly IPermissionRolesRepository _perRoleRepo;
        private readonly IUserRoleRepository _userRoleRepo;
        public UserRoleServices(IPermissionRolesRepository perRoleRepo, IUserRoleRepository userRoleRepo)
        {
            _perRoleRepo = perRoleRepo;
            _userRoleRepo = userRoleRepo;
        }
        public List<PermissionRoles> GetAllPermissionAndRoles()
        {
            return _perRoleRepo.Get();
        }
        public User CreateUserRole(User user, List<int> userRole)
        {
            if (userRole != null)
            {
                foreach (var roleId in userRole)
                {
                    var userRoles = new UserRoles { UserId = user.Id, RoleId = roleId };
                    _userRoleRepo.Create(userRoles);
                }
            }
            return null;
        }
    }
}
