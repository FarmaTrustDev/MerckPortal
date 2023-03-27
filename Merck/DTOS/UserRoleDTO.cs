using Merck.Models;
using System;
using System.Collections.Generic;

namespace Merck.DTOS
{
    public class UserRoleDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool? Active { get; set; }
        public Guid? GlobalId { get; set; }
        public List<Roles> Roles { get; set; }
    }
}
