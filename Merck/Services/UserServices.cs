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
    }
}
