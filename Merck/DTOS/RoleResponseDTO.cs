using Merck.Models;
using System;
using System.Collections.Generic;

namespace Merck.DTOS
{
    public class RoleResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Permissions> Permissions { get; set; }
        public Guid? GlobalId { get; set; }
        public bool? Active { get; set; }
    }
}
