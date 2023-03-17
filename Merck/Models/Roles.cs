using System.Collections;
using System.Collections.Generic;

namespace Merck.Models
{
    public class Roles : BaseModel
    {
        public string Name { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
        public ICollection<PermissionRoles> PermissionRoles { get; set; }
    }
}
