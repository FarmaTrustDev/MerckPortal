using Merck.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Merck.DTOS
{
    public class EventResponseDTO
    {
        public int SelectedItemId { get; set; }
        public List<TreatmentEvent> TreatmentEvents { get; set; }
    }
    public class DeviceListResponseDTO
    {
        public int SelectedItemId { get; set; }
        public SelectList Devices { get; set; }
    }
}
