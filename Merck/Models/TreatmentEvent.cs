using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merck.Models
{
    public class TreatmentEvent : BaseModel
    {
        public string DeviceSerialNumber { get; set; }
        public string Event { get; set; }
        public string RecordType { get; set; }
        public DateTime Timestamp { get; set; }
        public string TransmissionId { get; set; }
        public DateTime TransmissionTime { get; set; }
        public double Value { get; set; }
        public string Hash { get; set; }
    }
}
