﻿using Merck.Models;

namespace Merck.DTOS
{
    public class DeviceResponseDTO
    {
        public string DeviceName { get; set; }
        public TreatmentEvent TreatmentEvent { get; set; }
    }
}
