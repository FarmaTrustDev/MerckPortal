using Merck.DTOS;
using Merck.Helpers;
using Merck.Models;
using Merck.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Merck.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TreatmentEventServices _treatmentEventservices;
        public HomeController(ILogger<HomeController> logger, TreatmentEventServices treatmentEventservices)
        {
            _logger = logger;
            _treatmentEventservices = treatmentEventservices;
        }

        /*public List<DeviceDTO> GetAllDevices()
        {
            List<DeviceDTO> devices = new List<DeviceDTO>()
            {
                new DeviceDTO
                {
                    Id= 1,
                    Name= "EasyPod 1",
                },
                new DeviceDTO
                {
                    Id= 2,
                    Name= "EasyPod 2",
                }
            };
            
            return devices;
        }*/
        public List<StatsDTO> GetAllDevicesStats()
        {
            var countryData = _treatmentEventservices.GetBarChartStats();
            return countryData;
        }
        public StatsDTO GetStats(string deviceId)
        {
            var selectedDeviceId = deviceId;
            /*List<StatsDTO> stats = new List<StatsDTO>()
            {
                 new StatsDTO
                {
                    NoOfTransmission = 20,
                    DeviceTypes = 26,
                    Distribution = 30,
                    OverallAttacks = 12,
                    TransmissionError = 8,
                    DeviceId = 1
                },
                new StatsDTO
                {
                    NoOfTransmission = 12,
                    DeviceTypes = 36,
                    Distribution = 19,
                    OverallAttacks = 9,
                    TransmissionError = 3,
                    DeviceId = 2
                },
            };*/

            //var getDeviceStat = stats.Where(x => x.DeviceId == selectedDeviceId).FirstOrDefault();
            var getDeviceStat = _treatmentEventservices.GetStats(deviceId);
            return getDeviceStat;
        }
        public IActionResult Index()
        {
            var data = new SelectList(AppConstants.GetAllDevicesExcludingAll());
            var countryData = _treatmentEventservices.GetCountryStats();

            ViewBag.Devices = data;
            ViewBag.Country = countryData;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
