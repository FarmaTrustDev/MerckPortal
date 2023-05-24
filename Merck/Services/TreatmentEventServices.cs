using Merck.DTOS;
using Merck.Helpers;
using Merck.Interfaces.Repositories;
using Merck.Models;
using Merck.Repositories;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.WebRequestMethods;

namespace Merck.Services
{
    public class TreatmentEventServices
    {
        private readonly ITreatmentEventRepository _treatmentEventRepo;
        private readonly string _directoryPath;
        private readonly IDocumentRepository _documentRepo;
        public TreatmentEventServices(IDocumentRepository documentRepo,ITreatmentEventRepository treatmentEventRepo, IConfiguration configuration)
        {
            _treatmentEventRepo = treatmentEventRepo;
            _documentRepo = documentRepo;
            _directoryPath = configuration.GetValue<string>("FileWatcher:DirectoryPath");
        }   

        public List<TreatmentEvent> GetAllTreatmentEvent()
        {
            return _treatmentEventRepo.Get();
        }
        public List<TreatmentEvent> GetListofDeviceSerialNumber() //this was created to fetch the detail from the structured storage
        {
            return _treatmentEventRepo.GetAllDeviceSerialNumber();
        }
        public List<DeviceResponseDTO> GetDeviceSerialNumberList() // this has been defined to get from the logfile
        {
            return _treatmentEventRepo.GetDeviceSerialNumberList();
        }
        public int countData(List<FileLog> files, string deviceName)
        {
            return files.Where(dev => dev.DeviceName == deviceName).Count();
        }
        public bool checkData(List<FileLog> files, string deviceName, bool isTampaered, int tampCount)
        {
            int totCount = countData(files, deviceName);
            float deviceResultant = ((float)tampCount / (float)totCount * 100);
            if (isTampaered == true && deviceResultant < 20)
                return true;
            else
                return false;
        }
        public List<PatientJsonDTO> GetDeviceList() // this has been defined to get from the logfile
        {
            List<PatientJsonDTO> patientJsonDTOs= new List<PatientJsonDTO>();
            List<FileLog> files= _treatmentEventRepo.GetDeviceList();
            // tampCount, totCountEA2, totCountEA3, tamp are the hardcoded for temp rports for this temporary data
            int tampCountEA2 = 0;  // temp report data
            int tampCountEA3 = 0;  // temp report data
            bool tamp = false; // temp report data
            foreach (FileLog file in files)
            {
                PatientJsonDTO patientJsonDTO = new PatientJsonDTO();
                patientJsonDTO.DeviceName = file.DeviceName;
                patientJsonDTO.Node = AppConstants.GetCountryByDeviceName(file.DeviceName);
                TreatmentEvent treatmentEvent = file.Value!=null? JArray.Parse(file.Value).GroupBy(d => (string)d["device_serial_no"]).Select(g => new TreatmentEvent
                {
                    DeviceSerialNumber = (string)g.Key,
                    LongTransmissionTime = g.Max(t => (long)t["transmission_time"])
                }).OrderByDescending(t => t.LongTimestamp).FirstOrDefault() : null;
                patientJsonDTO.MerckHash = file.MerckHash;
                patientJsonDTO.LocalHash = file.Hash;
                patientJsonDTO.DeviceId = treatmentEvent.DeviceSerialNumber;
                patientJsonDTO.LastTransmissionDate = DateTime.FromBinary(treatmentEvent.LongTransmissionTime);
                
                if(file.Tempered == true)
                {
                    if(file.DeviceName=="EASYPOD2")
                    {
                        if (checkData(files, file.DeviceName, true, tampCountEA2)) { tampCountEA2++; tamp = true; } else { tamp = false; }
                            
                    }
                    if (file.DeviceName == "EASYPOD3")
                    {
                        if (checkData(files, file.DeviceName, true, tampCountEA3)) { tampCountEA3++; tamp = true; } else { tamp = false; }
                    }
                }
                else
                {
                    tamp = false;
                }
                List<StepsDTO> stepsDTOs = new List<StepsDTO>();
                patientJsonDTO.Steps = new List<StepsDTO>
                {
                    new StepsDTO { Id = 1, Name = "Device", Status = "Completed"},
                    new StepsDTO { Id = 2, Name = "Validated", Status = "Completed"},
                    new StepsDTO { Id = 3, Name = "Non Tampered", Status = tamp==false ? "Completed" : "In Progress"},
                    new StepsDTO { Id = 4, Name = "Stored", Status =file.BlockChainTransactionId!=null ? "Completed" : "Remaining"},
                };
                patientJsonDTOs.Add(patientJsonDTO);
            }
            return patientJsonDTOs;
        }
        public List<DeviceResponseDTO> GetDeviceSerialNumberListByDevice(string device) // this has been defined to get from the logfile
        {
            return _treatmentEventRepo.GetDeviceSerialNumberListByDevice(device);
        }
        
        public List<TreatmentEvent> GetListofEventsWithTimeStampBySerialNumber(string serialNo, string events)
        {
            return _treatmentEventRepo.GetListofEventsWithTimeStampBySerialNumber(serialNo, events);
        }
        public List<TreatmentEvent> GetListofEventsBySerialNumber(string serialNo)
        {
            return _treatmentEventRepo.GetListofEventsBySerialNumber(serialNo);
        }
        public string GetTreatmentEventByEventAndTimeStamp(string events, long timestamp)
        {
            return _treatmentEventRepo.GetTreatmentEventByEventAndTimeStamp(events, timestamp);
        }
        public StatsDTO GetStats(string deviceName)
        {
            return _treatmentEventRepo.GetStats(deviceName);
        }
        public StatsDTO GetStatsByDate(string deviceName, string fromDate, string toDate)
        {
            return _treatmentEventRepo.GetStatsByDate(deviceName, fromDate, toDate);
        }
        public List<StatsDTO> GetCountryStats()
        {
            return _treatmentEventRepo.GetCountryStats();
        }
        public List<StatsDTO> GetBarChartStats()
        {
            List <StatsDTO> statsDTOs= _treatmentEventRepo.GetCountryStats();
            /*List<BarChartStats> barChartStats = new List<BarChartStats>();
            foreach(StatsDTO statsDTO in statsDTOs)
            {
                BarChartStats chartStats = new BarChartStats();
                List<ChartCoordinates> chartCoordinates = new List<ChartCoordinates>();
                chartCoordinates.Add(new ChartCoordinates { X = "No of Transmissions", Y = statsDTO.NoOfTransmission });
                chartCoordinates.Add(new ChartCoordinates { X = "Distribution", Y = statsDTO.Distribution });
                chartCoordinates.Add(new ChartCoordinates { X = "Transmission Errors", Y = statsDTO.TransmissionError });
                chartCoordinates.Add(new ChartCoordinates { X = "Overall Attacks", Y = statsDTO.OverallAttacks });
                chartStats.MarkerType = "square";
                chartStats.ShowInLegend = true;
                chartStats.Type = "Line";
                chartStats.Name = statsDTO.DeviceType;
                chartStats.DataPoints = chartCoordinates;
                barChartStats.Add(chartStats);
            }*/
            return statsDTOs;
        }

        public List<TreatmentEvent> ProcessFile(string fileName)
        {  
            var filePath = Path.Combine(_directoryPath, fileName);
            var json = System.IO.File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<TreatmentEventRequestDTO[]>(json);
            Document document = new Document();
            document.Active = true;
            document.DocumentName = fileName;
            document= _documentRepo.Create(document).Result;
            List<TreatmentEvent> treatmentEvents = new List<TreatmentEvent>();
            foreach(TreatmentEventRequestDTO treatmentEventRequest in data)
            {
                TreatmentEvent treatmentEvent = new TreatmentEvent();
                treatmentEvent.documentId = document.Id;
                treatmentEvent.InjectedDose = treatmentEventRequest.injected_dose;
                treatmentEvent.CartridgeContent = treatmentEventRequest.cartridge_content;
                treatmentEvent.Active = true;
                treatmentEvent.DeviceSerialNumber = treatmentEventRequest.device_serial_no;
                treatmentEvent.Event = treatmentEventRequest.Event;
                treatmentEvent.Hash = treatmentEventRequest.Hash;
                treatmentEvent.PrescribedDose = treatmentEventRequest.prescribed_dose;
                treatmentEvent.PrescribedDoseFrequency = treatmentEventRequest.prescribed_dose_frequency;
                treatmentEvent.Value = treatmentEventRequest.Value;
                treatmentEvent.RecordType = treatmentEventRequest.record_type;
                treatmentEvent.LongTimestamp = treatmentEventRequest.timestamp.Value;
                treatmentEvent.LongTransmissionTime = treatmentEventRequest.timestamp.Value;
                if (treatmentEventRequest.timestamp != null)
                {
                    DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(treatmentEventRequest.timestamp.Value);
                    DateTime dateTime = dateTimeOffset.LocalDateTime;
                    treatmentEvent.Timestamp = dateTime;
                }
                if (treatmentEventRequest.transmission_time != null)
                {
                    DateTimeOffset dateTransTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(treatmentEventRequest.transmission_time.Value);
                    DateTime dateTransTime = dateTransTimeOffset.LocalDateTime;
                    treatmentEvent.TransmissionTime = dateTransTime;
                }
                treatmentEvents.Add(treatmentEvent);
            }
            _treatmentEventRepo.AddTreatmentEvents(treatmentEvents);
            return null;
        }
            

    }
}
