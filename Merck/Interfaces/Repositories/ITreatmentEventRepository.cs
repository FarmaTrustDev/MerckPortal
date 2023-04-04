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
        public List<TreatmentEvent> GetDeviceSerialNumberList(); 
        public List<TreatmentEvent> GetListofEventsWithTimeStampBySerialNumber(string SerialNo);
        public string GetTreatmentEventByEventAndTimeStamp(string events, long timestamp);
    }
}
