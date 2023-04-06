using Merck.DTOS;
using Merck.Models;
using Microsoft.AspNetCore.Mvc;
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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public JsonResult DeviceJson()
        {
            List<DeviceDTO> devices = new List<DeviceDTO>()
            {
                new DeviceDTO
                {
                    Id= 1,
                    Name= "Bot 1",
                    Stats = new StatsDTO
                    {
                        NoOfTransmission = 12, DeviceTypes = 36, Distribution = 19, OverallAttacks = 9, TransmissionError = 3
                    },
                },
                new DeviceDTO
                {
                    Id= 2,
                    Name= "Bot 2",
                    Stats = new StatsDTO
                    {
                        NoOfTransmission = 20, DeviceTypes = 26, Distribution = 30, OverallAttacks = 12, TransmissionError = 8
                    },
                }
            };
            return Json(devices);
        }
        public IActionResult Index()
        {
            var data = DeviceJson();
            ViewBag.DeviceData = data;
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
