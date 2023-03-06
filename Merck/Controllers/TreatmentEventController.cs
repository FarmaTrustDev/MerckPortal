using Merck.Repositories;
using Merck.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
