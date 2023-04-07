using System.Collections.Generic;

namespace Merck.DTOS
{
    public class DeviceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StatsDTO Stats { get; set; }
    }
}
