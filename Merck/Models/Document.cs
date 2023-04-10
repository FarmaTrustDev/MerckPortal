using System.Collections;
using System.Collections.Generic;

namespace Merck.Models
{
    public class Document : BaseModel
    {
        public string DocumentName { get; set; }
        public string Description { get; set; }
        public string Contents { get; set; }
        public ICollection<TreatmentEvent> TreatmentEvents { get; set; }
    }
}
