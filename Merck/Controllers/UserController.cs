using Merck.DTOS;
using Merck.Models;
using Merck.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Merck.Controllers
{
    public class UserController : Controller
    {
        private readonly UserServices _userServices;
        private readonly RoleServices _roleServices;
        private readonly UserRoleServices _userRoleServices;
        public UserController(UserServices userServices, RoleServices roleServices, UserRoleServices userRoleServices)
        {
            _userServices = userServices;
            _roleServices = roleServices;
            _userRoleServices = userRoleServices;
        }

        public IActionResult Index()
        {
			ViewBag.Users = _userServices.GetAllUserWithRoles();
			return View();
        }
        public IActionResult GetAllUser()
        {
            ViewBag.Users = _userServices.GetAllUserWithRoles();
            return View("Index");
        }
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Roles = _roleServices.GetAllRoles();
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult CreateUserWithRole([Bind("Id,UserName,FirstName, LastName, Email, UserRoles")] User user, int[] UserRoles)
        {
            if (ModelState.IsValid)
            {
                _userServices.CreateUser(user);
                _userRoleServices.CreateUserRole(user, UserRoles.ToList());
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
    }
}
