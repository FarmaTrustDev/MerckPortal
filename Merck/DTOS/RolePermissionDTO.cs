using System.Collections.Generic;

namespace Merck.DTOS
{
    public class RolePermissionDTO
    {
        public string RoleName { get; set; }
        public List<string> PermissionsName { get; set; }
    }
}
