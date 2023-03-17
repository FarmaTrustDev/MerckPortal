using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Merck.Models
{
    public class User: PersonnelBaseModel
    {
        [Column(TypeName = "nvarchar(40)")]
        public string UserName { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string Password { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
