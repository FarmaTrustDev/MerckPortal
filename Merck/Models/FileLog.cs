
using System.ComponentModel.DataAnnotations.Schema;

namespace Merck.Models
{
    public class FileLog : BaseModel
    {
        public string Name { get; set; }

        public string Hash { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Value { get; set; }

        public bool Tempered { get; set; }

    }
}
