namespace Merck.Models
{
    public class PermissionRoles : BaseModel
    {
        public int PermissionId { get; set; }
        public int RoleId { get; set; }
        public Permissions Permission { get; set; }
        public Roles Role { get; set; }
    }
}
