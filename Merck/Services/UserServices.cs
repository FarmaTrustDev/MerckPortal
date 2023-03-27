using Merck.DTOS;
using Merck.Helpers.Auth;
using Merck.Interfaces.Repositories;
using Merck.Models;
using System;
using System.Collections.Generic;

namespace Merck.Services
{
    public class UserServices
    {
        private readonly IUserRepositories _userRepo;
        public UserServices(IUserRepositories userRepo)
        {
            _userRepo = userRepo;
        }
        public List<User> GetAllUser()
        {
            return _userRepo.Get();
        }
        public List<UserRoleDTO> GetAllUserWithRoles()
        {
            return _userRepo.GetAllUserWithRoles();
        }
        public User CreateUser(User user)
        {
            user.Password = Utility.Encrypt("test123");
            user.Active = true;
			return _userRepo.Create(user).Result;
        }
		public User UpdateUser(User user)
		{
            Guid? gId = user.GlobalId;
            User checkUser = _userRepo.GetUserByGuid(gId.Value);
            checkUser.Active = true;
            checkUser.FirstName = user.FirstName;
            checkUser.LastName = user.LastName;
			return _userRepo.Update(checkUser).Result;
		}
		public UserRoleDTO GetUserWithRolesByUserId(Guid id)
        {
            UserRoleDTO userRoleDTO = new UserRoleDTO();
            userRoleDTO=_userRepo.GetUserWithRolesByUserId(id);
            return userRoleDTO;
        }
    }
}
