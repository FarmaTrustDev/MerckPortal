
using System.ComponentModel.DataAnnotations.Schema;

namespace Merck.Models
{
    public class FileLog : BaseModel
    {
        public string Name { get; set; }


        public string HashFileName { get; set; }

        public string MerckHash { get; set; }

        public string Hash { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Value { get; set; }

        public bool Tempered { get; set; }

        public long CreatedOn { get; set; }
        public string BlockChainTransactionId { get; set; }

    }
}
