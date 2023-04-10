using Merck.DTOS;
using Merck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merck.Interfaces.Repositories
{
    public interface ITreatmentEventRepository: IBaseRepository<TreatmentEvent>
    {
        public void AddTreatmentEvents(List<TreatmentEvent> TreatmentEvents);
        public List<TreatmentEvent> GetAllDeviceSerialNumber();
        public List<DeviceResponseDTO> GetDeviceSerialNumberList();
        public List<TreatmentEvent> GetListofEventsWithTimeStampBySerialNumber(string serialNo, string events);
        public List<TreatmentEvent> GetListofEventsBySerialNumber(string serialNo); 
        public string GetTreatmentEventByEventAndTimeStamp(string events, long timestamp);
        public List<DeviceResponseDTO> GetDeviceSerialNumberListByDevice(string device);
        public StatsDTO GetStats(string deviceName);
        public List<StatsDTO> GetCountryStats();
        
    }
}
