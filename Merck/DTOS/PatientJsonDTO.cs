using Merck.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Merck.DTOS
{
    public class PatientJsonDTO
    {
        public int Id { get; set; }
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string Node { get; set; }
        public string MerckHash { get; set; }
        public string LocalHash { get; set; }
        public DateTime LastTransmissionDate { get; set; }
        public List<StepsDTO> Steps { get; set; }
    }
}
