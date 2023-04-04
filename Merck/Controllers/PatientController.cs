using Merck.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Merck.Controllers
{
	public class PatientController : Controller
	{
		public IActionResult Index()
		{
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
                            new StepsDTO { Id = 3, Name = "Non Temperatured", Status = "Completed"},
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
                        new StepsDTO { Id = 3, Name = "Non Temperatured", Status = "In Progress"},
                        new StepsDTO { Id = 4, Name = "Stored", Status = "Remaining"},
                        new StepsDTO { Id = 5, Name = "Analyze", Status = "Remaining"},
                        new StepsDTO { Id = 6, Name = "Done", Status = "Remaining"},
                    },
                },
            };
            ViewBag.JsonData = objects;
            return View();
		}
	}
}
