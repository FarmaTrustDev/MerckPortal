using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Merck.DTOS
{
    public class ReadFileDTO
    {

        public string Name { get; set; }

        public string Hash { get; set; }

        public string Value { get; set; }

        public bool Tempered { get; set; }
    }
}
