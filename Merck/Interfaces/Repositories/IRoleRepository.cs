using Merck.DTOS;
using Merck.Models;
using System.Collections.Generic;

namespace Merck.Interfaces.Repositories
{
    public interface IRoleRepository : IBaseRepository<Roles>
    {
        public List<RoleResponseDTO> GetRolesWithPermissions();
    }
}
