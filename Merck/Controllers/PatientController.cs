using Merck.DTOS;
using Merck.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Merck.Controllers
{
	public class PatientController : Controller
	{
        private readonly TreatmentEventServices _treatmentEventservices;
        public PatientController(TreatmentEventServices treatmentEventservices)
        {
            _treatmentEventservices = treatmentEventservices;
        }
        public IActionResult Index()
		{
            ViewBag.JsonData = _treatmentEventservices.GetDeviceList(); ;
            return View();
		}
        public IActionResult ViewConductSteps()
        {
            List<StepsResponseDTO> steps = new List<StepsResponseDTO>()
            {
                new StepsResponseDTO
                {
                    StepName = "Validation Step # 1",
                    StepCompletedDate= DateTime.Now,
                    CompletedBy = "Raja Sharif",
                    ManfName = "Baystate Clinic"
                },
                new StepsResponseDTO
                {
                    StepName = "Validation Step # 2",
                    StepCompletedDate= DateTime.Now,
                    CompletedBy = "Raja Sharif",
                    ManfName = "Baystate Clinic"
                },
                new StepsResponseDTO
                {
                    StepName = "Validation Step # 3",
                    StepCompletedDate= DateTime.Now,
                    CompletedBy = "Raja Sharif",
                    ManfName = "Baystate Clinic"
                },

            };
            List<PatientJsonDTO> objects = new List<PatientJsonDTO>()
            {
                new PatientJsonDTO {
                        Id = 1,
                        DeviceId = "20933274",
                        LastTransmissionDate = DateTime.Now,
                        Node = "West Europe",
                        Steps = new List<StepsDTO>
                        {
                            new StepsDTO { Id = 1, Name = "Device", Status = "Completed"},
                            new StepsDTO { Id = 2, Name = "Validated", Status = "Completed"},
                            new StepsDTO { Id = 3, Name = "Non Tempered", Status = "Completed"},
                            new StepsDTO { Id = 4, Name = "Stored", Status = "In Progress"},
                            new StepsDTO { Id = 5, Name = "Analyze", Status = "Remaining"},
                            new StepsDTO { Id = 6, Name = "Done", Status = "Remaining"},
                        }
                },
                new PatientJsonDTO {
                    Id = 2,
                    DeviceId = "20933275",
                    LastTransmissionDate = DateTime.Now,
                    Node = "Egypt",
                    Steps = new List<StepsDTO>
                    {
                        new StepsDTO { Id = 1, Name = "Device", Status = "Completed"},
                        new StepsDTO { Id = 2, Name = "Validated", Status = "Completed"},
                        new StepsDTO { Id = 3, Name = "Non Tempered", Status = "In Progress"},
                        new StepsDTO { Id = 4, Name = "Stored", Status = "Remaining"},
                        new StepsDTO { Id = 5, Name = "Analyze", Status = "Remaining"},
                        new StepsDTO { Id = 6, Name = "Done", Status = "Remaining"},
                    },
                },
            };
            ViewBag.JsonData = objects;
            ViewBag.ConductSteps = steps;
            ViewBag.ShowDiv = true;
            return View("Index");
        }
        public IActionResult ConductSteps()
        {
            
            return View();
        }
	}
}
