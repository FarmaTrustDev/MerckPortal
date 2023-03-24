using Merck.Interfaces.Repositories;
using Merck.Models;
using Merck.Repositories;
using System.Collections.Generic;

namespace Merck.Services
{
    public class PermissionServices
    {
        private readonly IPermissionsRepository _permissionRepo;
        public PermissionServices(IPermissionsRepository permissionRepo)
        {
            _permissionRepo = permissionRepo;
        }
        public List<Permissions> GetAllPermissions()
        {
            return _permissionRepo.Get();
        }
		public Permissions CreatePermissions(Permissions permission)
		{
			return _permissionRepo.Create(permission).Result;
		}
	}
}
