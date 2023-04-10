using Merck.DTOS;
using Merck.Helpers;
using Merck.Interfaces.Repositories;
using Merck.Models;
using Microsoft.Extensions.Logging;
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
                    Location=AppConstants.GetCountryByDeviceName(dv.DeviceName),
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
        public List<DeviceResponseDTO> GetDeviceSerialNumberListByDevice(string device)
        {
            try
            {
                var result = _dbContext.FileLog.Where(val => val.Value != null && val.DeviceName==device)
                .Select(val => new { Value = val.Value, DeviceName = val.DeviceName }) // Include DeviceName in the anonymous type
                .ToList()
                .Select(dv => new DeviceResponseDTO
                {
                    DeviceName = dv.DeviceName,
                    Location = AppConstants.GetCountryByDeviceName(dv.DeviceName),
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
        public List<TreatmentEvent> GetListofEventsWithTimeStampBySerialNumber(string serialNo, string events)
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
            .SelectMany(jsonArray => JArray.Parse(jsonArray)).Where(t => (string)t["device_serial_no"]== serialNo.Trim(' ') && (string)t["event"] == events.Trim(' ')).AsEnumerable()
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
        public List<TreatmentEvent> GetListofEventsBySerialNumber(string serialNo)
        {
            var treatmentEvent = _dbContext.FileLog.Where(val => val.Value != null).Select(val => val.Value).ToList();
            List<TreatmentEvent> result = treatmentEvent
            .SelectMany(jsonArray => JArray.Parse(jsonArray)).Where(t => (string)t["device_serial_no"] == serialNo.Trim(' ')).AsEnumerable()
            .GroupBy(d => new { Event = (string)d["event"], DeviceSerialNumber = (string)d["device_serial_no"]})
            .Select(g => new TreatmentEvent
            {
                Event = g.Key.Event,
                DeviceSerialNumber = g.Key.DeviceSerialNumber
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
        public List<StatsDTO> GetCountryStats()
        {
            List<StatsDTO> statsDTOs = new List<StatsDTO>();
            var data = AppConstants.GetAllDevicesExcludingAll();
            foreach(var item in data)
            {
                StatsDTO statsDTO = new StatsDTO();
                statsDTO.DeviceType = item;
                statsDTO.NoOfTransmission = GetTotalNoOfTransmissions(item);
                statsDTO.OverallAttacks = GetTotalAttacks(item);
                statsDTO.TransmissionError = GetTotalTransmissionErrors(item);
                statsDTO.Distribution = GetTotalDevicesPerCountry(item);
                statsDTOs.Add(statsDTO);
            }
            return statsDTOs;
        }
        public StatsDTO GetStats(string deviceName)
        {
            StatsDTO statsDTO = new StatsDTO();
            statsDTO.NoOfTransmission = GetTotalNoOfTransmissions(deviceName);
            statsDTO.OverallAttacks = GetTotalAttacks(deviceName);
            statsDTO.TransmissionError = GetTotalTransmissionErrors(deviceName);
            statsDTO.Distribution = GetTotalDevicesPerCountry(deviceName);
            return statsDTO;
        }

        public int GetTotalNoOfTransmissions(string deviceName)
        {
            var treatmentEvent = _dbContext.FileLog.Where(val => val.Value != null && val.DeviceName == deviceName).Select(val => val.Value).ToList();
            var result = treatmentEvent
            .SelectMany(jsonArray => JArray.Parse(jsonArray))
            .Count();
            return result;
        }
        public int GetTotalAttacks(string deviceName)
        {
            var treatmentEvent = _dbContext.FileLog.Where(val => val.MerckHash != val.Hash && val.DeviceName == deviceName).Count();
            return treatmentEvent;
        }
        public int GetTotalTransmissionErrors(string deviceName)
        {
            var treatmentEvent = _dbContext.FileLog.Where(val => val.Value == null && val.DeviceName == deviceName).Count();
            return treatmentEvent;
        }
        public int GetTotalDevicesPerCountry(string deviceName)
        {
            var treatmentEvent = _dbContext.FileLog.Where(val => val.DeviceName == deviceName).Count();
            return treatmentEvent;
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
