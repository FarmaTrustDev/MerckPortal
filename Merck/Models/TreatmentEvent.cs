using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merck.Models
{
    public class TreatmentEvent : BaseModel
    {
        public int documentId { get; set; }
        public Document Document { get; set; }
        public string DeviceSerialNumber { get; set; }
        public string Event { get; set; }
        public string RecordType { get; set; }
        public DateTime? Timestamp { get; set; }
        public long LongTimestamp { get; set; }
        public string TransmissionId { get; set; }
        public DateTime? TransmissionTime { get; set; }
        public long LongTransmissionTime { get; set; }
        public double? Value { get; set; }
        public string Hash { get; set; }
        public double? PrescribedDoseFrequency { get; set; }
        public double? PrescribedDose { get; set; }
        public double? InjectedDose { get; set; }
        public double? CartridgeContent { get; set; }
        public string BlockChainTransactionId { get; set; }
    }
}
