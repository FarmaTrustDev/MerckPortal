using Merck.Interfaces.Repositories;
using Merck.Models;
using System.Collections.Generic;

namespace Merck.Services
{
    public class UserRoleServices
    {
        private readonly IPermissionRolesRepository _perRoleRepo;
        private readonly IUserRoleRepository _userRoleRepo;
		private readonly IUserRepositories _userRepo;
		public UserRoleServices(IUserRepositories userRepo,IPermissionRolesRepository perRoleRepo, IUserRoleRepository userRoleRepo)
        {
            _perRoleRepo = perRoleRepo;
            _userRoleRepo = userRoleRepo;
            _userRepo = userRepo;
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
                    userRoles.Active = true;
                    _userRoleRepo.Create(userRoles);
                }
            }
            return null;
        }
		public User UdateUserRoles(User user, List<int> userRole)
		{
			if (userRole != null)
			{
                int userId = _userRepo.GetUserByGuid(user.GlobalId.Value).Id;
                _userRoleRepo.DeleteUserRoleByUserId(userId);
				foreach (var roleId in userRole)
				{   
					var userRoles = new UserRoles { UserId = userId, RoleId = roleId };
                    userRoles.Active = true;
					_userRoleRepo.Create(userRoles);
				}
			}
			return null;
		}
	}
}
