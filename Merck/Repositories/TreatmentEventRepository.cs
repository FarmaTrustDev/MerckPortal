using Merck.DTOS;
using Merck.Interfaces.Repositories;
using Merck.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merck.Repositories
{
    public class TreatmentEventRepository : BaseRepository<TreatmentEvent>, ITreatmentEventRepository
    {
        private readonly MyDbContext _dbContext;
        public TreatmentEventRepository(MyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddTreatmentEvents(List<TreatmentEvent> TreatmentEvents)
        {
            _dbContext.AddRange(TreatmentEvents);
            _dbContext.SaveChanges();
        }
        public List<TreatmentEvent> GetAllDeviceSerialNumber()
        {
            return _dbContext.TreatmentEvent.AsEnumerable()
                .GroupBy(t => t.DeviceSerialNumber)
                .Select(g => new TreatmentEvent
                {
                    DeviceSerialNumber = g.Key,
                    Timestamp = g.Max(t => t.Timestamp)
                })
                .OrderByDescending(t => t.Timestamp)
                .ToList();
        }
        public List<DeviceResponseDTO> GetDeviceSerialNumberList()
        {
            /*var treatmentEvent = _dbContext.FileLog.Select(val => new { val.Value, val.DeviceName }).ToList();
            List<TreatmentEvent> result = treatmentEvent
            .SelectMany(jsonArray => JArray.Parse(jsonArray.Value))
            .GroupBy(d => (string)d["device_serial_no"])
            .Select(g=> new TreatmentEvent
            {
                DeviceSerialNumber = (string)g.Key,
                Hash= g.First().DeviceName,
                LongTimestamp = g.Max(t =>(long)t["timestamp"])
            })
            .OrderByDescending(t => t.LongTimestamp)
            .ToList();
            return result;*/
            try
            {
                var result = _dbContext.FileLog.Where(val=>val.Value!=null)
                .Select(val => new { Value = val.Value, DeviceName = val.DeviceName }) // Include DeviceName in the anonymous type
                .ToList()
                .Select(dv => new DeviceResponseDTO
                {
                    DeviceName = dv.DeviceName,
                    TreatmentEvent = JArray.Parse(dv.Value).GroupBy(d => (string)d["device_serial_no"]).Select(g => new TreatmentEvent
                    {
                        DeviceSerialNumber = (string)g.Key,
                        LongTimestamp = g.Max(t => (long)t["timestamp"])
                    }).OrderByDescending(t => t.LongTimestamp).FirstOrDefault()
                }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<TreatmentEvent> GetListofEventsWithTimeStampBySerialNumber(string serialNo)
        {
            // Earlier created to fetch data from the treatmentevent table
            /*return _dbContext.TreatmentEvent.Where(x=>x.DeviceSerialNumber== serialNo).AsEnumerable()
                .GroupBy(t => new { t.Event, t.Timestamp, t.LongTimestamp })
                .Select(g => new TreatmentEvent
                {
                    Event = g.Key.Event,
                    Timestamp = g.Key.Timestamp,
                    LongTimestamp=g.Key.LongTimestamp,
                })
                .ToList();*/
            var treatmentEvent = _dbContext.FileLog.Where(val=>val.Value!=null).Select(val => val.Value).ToList();
            
            List<TreatmentEvent> result = treatmentEvent
            .SelectMany(jsonArray => JArray.Parse(jsonArray)).Where(t => (string)t["device_serial_no"]== serialNo).AsEnumerable()
            .GroupBy(d => new {Event=(string)d["event"], DeviceSerialNumber=(string)d["device_serial_no"], LongTimestamp=(long)d["timestamp"]  })
            .Select(g => new TreatmentEvent
            {
                Event=g.Key.Event,
                DeviceSerialNumber = g.Key.DeviceSerialNumber,
                LongTimestamp = g.Key.LongTimestamp
            })
            .ToList();
            return result;
        }
        public string GetTreatmentEventByEventAndTimeStamp(string events, long timestamp)
        {
            // return _dbContext.TreatmentEvent.Where(t=>t.Event==Events && t.LongTimestamp==Timestamp).FirstOrDefault();
            var treatmentEvent = _dbContext.FileLog.Where(val => val.Value != null).Select(val => val.Value).ToList();
            var result = treatmentEvent
            .SelectMany(jsonArray => JArray.Parse(jsonArray))
            .Where(t => (string)t["event"] == events.Trim(' ') && (long)t["timestamp"] == timestamp)
            .FirstOrDefault();
            return result.ToString();
        }
        public bool IsValidJson(string input)
        {
            input = input.Trim();
            if ((input.StartsWith("{") && input.EndsWith("}")) || //For object
                (input.StartsWith("[") && input.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(input);
                    return true;
                }
                catch (JsonReaderException)
                {
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
