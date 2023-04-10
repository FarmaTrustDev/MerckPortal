using System;

namespace Merck.DTOS
{
    public class TreatmentEventRequestDTO
    {
        public string device_serial_no { get; set; }
        public string Event { get; set; }
        public string record_type { get; set; }
        public long? timestamp { get; set; }
        public string transmission_id { get; set; }
        public long? transmission_time { get; set; }
        public double? Value { get; set; }
        public string Hash { get; set; }
        public double? prescribed_dose_frequency { get; set; }
        public double? prescribed_dose { get; set; }
        public double? injected_dose { get; set; }
        public double? cartridge_content { get; set; }
        public string BlockChainTransactionId { get; set; }
    }
}
