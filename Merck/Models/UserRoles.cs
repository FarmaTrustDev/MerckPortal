namespace Merck.Models
{
    public class UserRoles : BaseModel
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public User User { get; set; }
        public Roles Role { get; set; }
    }
}
