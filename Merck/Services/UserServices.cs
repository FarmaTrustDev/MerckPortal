using Merck.DTOS;
using Merck.Helpers.Auth;
using Merck.Interfaces.Repositories;
using Merck.Models;
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
			return _userRepo.Create(user).Result;
        }
    }
}
