using Merck.DTOS;
using Merck.DTOS.Auth;
using Merck.Models;
using System;
using System.Collections.Generic;

namespace Merck.Interfaces.Repositories
{
    public interface IUserRepositories: IBaseRepository<User>
    {
        User GetUser(AuthRequest userMode);
        public List<UserRoleDTO> GetAllUserWithRoles();
        public UserRoleDTO GetRolesByUserId(string UserId);
        public UserRoleDTO GetUserWithRolesByUserId(Guid id);
        public User GetUserByGuid(Guid globalId);

	}
}
