using Merck.DTOS;
using Merck.Interfaces.Repositories;
using Merck.Models;
using Merck.Repositories;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

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
        public List<TreatmentEvent> GetDeviceSerialNumberList() // this has been defined to get from the logfile
        {
            return _treatmentEventRepo.GetDeviceSerialNumberList();
        }
        public List<TreatmentEvent> GetListofEventsWithTimeStampBySerialNumber(string serialNo)
        {
            return _treatmentEventRepo.GetListofEventsWithTimeStampBySerialNumber(serialNo);
        }
        public string GetTreatmentEventByEventAndTimeStamp(string events, long timestamp)
        {
            return _treatmentEventRepo.GetTreatmentEventByEventAndTimeStamp(events, timestamp);
        }
        public List<TreatmentEvent> ProcessFile(string fileName)
        {  
            var filePath = Path.Combine(_directoryPath, fileName);
            var json = File.ReadAllText(filePath);
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
