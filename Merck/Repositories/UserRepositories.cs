
using Merck.DTOS;
using Merck.DTOS.Auth;
using Merck.Helpers.Auth;
using Merck.Interfaces.Repositories;
using Merck.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Merck.Repositories
{
    public class UserRepositories: BaseRepository<User>, IUserRepositories
    {
        private readonly MyDbContext _dbContext;
        public UserRepositories(MyDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }
        public User GetUser(AuthRequest userModel)
        {
            User user= _dbContext.User.Where(x => x.UserName.ToLower() == userModel.Username.ToLower()
                && x.Password == Utility.Encrypt(userModel.Password)).FirstOrDefault();
            return user;
        }
        public List<UserRoleDTO> GetAllUserWithRoles()
        {
            List<UserRoleDTO> userRoleDTOs = _dbContext.User.Include(usr=>usr.UserRoles).Select(role=> new UserRoleDTO()
            {
                Id=role.Id,
                FirstName=role.FirstName,
                LastName=role.LastName,
                GlobalId=role.GlobalId,
                Active=role.Active,
                UserName=role.UserName,
                Email=role.Email,
                Roles=role.UserRoles.Select(rol=>rol.Role).ToList(),
            }).ToList();
            return userRoleDTOs;
        }
    }
}
