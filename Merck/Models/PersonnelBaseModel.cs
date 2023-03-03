using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Merck.Models
{
    public class PersonnelBaseModel: BaseModel
    {
        [Column(TypeName = "nvarchar(40)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string LastName { get; set; }

        [Column(TypeName = "tinyint")]
        public byte Gender { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        public string Address { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Phone { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string PostCode { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public DateTime? DOB { get; set; }
    }
}
