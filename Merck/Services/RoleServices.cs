using Merck.DTOS;
using Merck.Interfaces.Repositories;
using Merck.Models;
using System.Collections.Generic;

namespace Merck.Services
{
    public class RoleServices
    {
        private readonly IRoleRepository _roleRepo;
        public RoleServices(IRoleRepository roleRepo)
        {
            _roleRepo = roleRepo;
        }
        public List<Roles> GetAllRoles()
        {
            return _roleRepo.Get();
        }
        public List<RoleResponseDTO> GetAllRolesWithPermissions()
        {
            return _roleRepo.GetRolesWithPermissions();
        }
        public Roles CreateRole(Roles role)
		{
            role.Active = true;
			return _roleRepo.Create(role).Result;
		}
	}
}
