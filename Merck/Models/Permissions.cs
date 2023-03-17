using System.Collections.Generic;

namespace Merck.Models
{
    public class Permissions : BaseModel
    {
        public string Name { get; set; }
        public ICollection<PermissionRoles> PermissionRoles { get; set; }
    }
}
