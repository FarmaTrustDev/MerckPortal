using Merck.Models;
using System.Collections.Generic;

namespace Merck.DTOS
{
    public class UserRolesResponseDTO
    {
        public string UserName { get; set; }
        public List<string> UserRoles { get; set; }
    }
}
