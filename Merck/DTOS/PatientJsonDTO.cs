using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Merck.DTOS
{
    public class PatientJsonDTO
    {
        public int Id { get; set; }
        public string DeviceId { get; set; }
        public string Node { get; set; }
        public DateTime LastTransmissionDate { get; set; }
        public List<StepsDTO> Steps { get; set; }
    }
}
