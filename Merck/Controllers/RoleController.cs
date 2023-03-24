using Merck.Filters;
using Merck.Models;
using Merck.Repositories;
using Merck.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace Merck.Controllers
{
    public class RoleController : Controller
    {
        public readonly RoleServices _roleService;
        public readonly PermissionServices _permissionService;
		public readonly PermissionRoleServices _permissionRoleService;
        public RoleController(PermissionRoleServices permissionRoleService,RoleServices roleService, PermissionServices permissionService)
        {
            _roleService = roleService;
            _permissionService = permissionService;
            _permissionRoleService = permissionRoleService;
		}
        // GET: RoleController
        public ActionResult Index()
        {
			ViewBag.Roles=_roleService.GetAllRolesWithPermissions();
            return View();
        }

        // GET: RoleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoleController/Create
        [Authorize]
        [AuthFilter(roles: new[] { "Admin" }, null, permissions: new[] { "Delete", "View" })]
        public ActionResult Create()
        {
            ViewBag.Permissions = _permissionService.GetAllPermissions();
            return View();
        }

        // POST: RoleController/Create
        
        [HttpPost]
		[Authorize]
        [AuthFilter(roles: new[] { "Admin"}, null, permissions: new[] { "Delete", "View" })]
        public IActionResult CreateRoleWithPermission([Bind("Id,Name, PermissionRoles")] Roles role, int[] PermissionRoles)
		{
			if (ModelState.IsValid)
			{
				_roleService.CreateRole(role);
                _permissionRoleService.CreatePermissionRole(role, PermissionRoles.ToList());
				
				return RedirectToAction(nameof(Index));
			}
			return View(role);
		}

		// GET: RoleController/Edit/5
		public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoleController/Edit/5
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

        // GET: RoleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoleController/Delete/5
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
