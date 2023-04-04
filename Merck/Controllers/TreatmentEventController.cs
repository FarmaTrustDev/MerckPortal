using Merck.DTOS;
using Merck.Models;
using Merck.Repositories;
using Merck.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Merck.Controllers
{
    
    public class TreatmentEventController : Controller
    {
        private readonly TreatmentEventServices _treatmentEventservices;
        public TreatmentEventController(TreatmentEventServices treatmentEventservices)
        {   
            _treatmentEventservices = treatmentEventservices;
        }
        // GET: TreatmentEventController
        public ActionResult TreatmentEventList()
        {
            var model = _treatmentEventservices.GetAllTreatmentEvent();
            return View(model);
        }
        public ActionResult TreatmentListByDeviceSerialNumber()
        {
            var model = _treatmentEventservices.GetDeviceSerialNumberList();
            return View(model);
        }

        public ActionResult ShowTreatmentData()
        {
            var serialNo = Request.Query["serialNo"];
            var model = _treatmentEventservices.GetListofEventsWithTimeStampBySerialNumber(serialNo);
            EventResponseDTO eventResponseDTO = new EventResponseDTO();
            eventResponseDTO.TreatmentEvents = model;
            eventResponseDTO.SelectedItemId = 0;
            return View(eventResponseDTO);
        }
        public IActionResult GetTreatmentEvent()
        {
            var events = Request.Query["event"];
            var timestamp=long.Parse(Request.Query["timestamp"]);
            // Retrieve the data based on the selected value
            var data = _treatmentEventservices.GetTreatmentEventByEventAndTimeStamp(events, timestamp);
            return Json(data);
        }
        [HttpPost]
        public IActionResult ProcessFile()
        {
            var fileName = Request.Form["fileName"];
            //_treatmentEventservices.ProcessFile(fileName);
            return View();
        }
        // GET: TreatmentEventController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TreatmentEventController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TreatmentEventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TreatmentEventController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TreatmentEventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TreatmentEventController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TreatmentEventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
