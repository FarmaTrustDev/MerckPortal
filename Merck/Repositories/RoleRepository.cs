using Merck.DTOS;
using Merck.Interfaces.Repositories;
using Merck.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Merck.Repositories
{
    public class RoleRepository : BaseRepository<Roles>, IRoleRepository
    {
        private readonly MyDbContext _dbContext;
        public RoleRepository(MyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public List<RoleResponseDTO> GetRolesWithPermissions()
        {
            List<RoleResponseDTO> roleResponseDTO = _dbContext.Roles
                .Include(role => role.PermissionRoles)
                .Select(rolePer => new RoleResponseDTO()
                {
                    Id=rolePer.Id,
                    Name=rolePer.Name,
                    GlobalId=rolePer.GlobalId,
                    Active=rolePer.Active,
                    Permissions=rolePer.PermissionRoles.Select(per=>per.Permission).ToList()
                }).ToList();
            return roleResponseDTO;
        }
    }
}
