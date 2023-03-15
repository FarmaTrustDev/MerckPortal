using Merck.Services;
using Microsoft.AspNetCore.Mvc;

namespace Merck.Controllers
{
    public class UserController : Controller
    {
        private readonly UserServices _userServices;
        public UserController(UserServices userServices)
        {
            _userServices = userServices;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllUser()
        {
            var model = _userServices.GetAllUser();
            return View("Index", model);
        }
    }
}
