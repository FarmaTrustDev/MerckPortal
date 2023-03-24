using Merck.Interfaces.Repositories;
using Merck.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Merck.Services
{
	public class PermissionRoleServices
	{
		private readonly IPermissionRolesRepository _perRoleRepo;
		public PermissionRoleServices(IPermissionRolesRepository perRoleRepo)
		{
			_perRoleRepo = perRoleRepo;
		}
		public List<PermissionRoles> GetAllPermissionAndRoles()
		{
			return _perRoleRepo.Get();
		}
		public Roles CreatePermissionRole(Roles role, List<int> perRole)
		{
			if (perRole != null)
			{
				foreach (var permissionId in perRole)
				{
					var rolePermission = new PermissionRoles { RoleId = role.Id, PermissionId = permissionId };
					_perRoleRepo.Create(rolePermission);
				}
			}
			return null;
		}
	}
}
