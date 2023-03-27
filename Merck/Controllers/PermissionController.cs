using Merck.Models;
using Merck.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Merck.Controllers
{
	public class PermissionController : Controller
	{
        public readonly PermissionServices _permissionService;
        public PermissionController(PermissionServices permissionService)
		{
			_permissionService = permissionService;

        }
		// GET: PermissionController
		public ActionResult Index()
		{
            ViewBag.Permissions = _permissionService.GetAllPermissions();
            return View();
		}

		// GET: PermissionController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: PermissionController/Create
		
		public ActionResult Create()
		{
			return View();
		}

        // POST: PermissionController/Create
        
        
		[HttpPost]
		[Authorize]
		public IActionResult CreatePermissions([Bind("Id,Name")] Permissions permission)
		{
			if (ModelState.IsValid)
			{
				_permissionService.CreatePermissions(permission);
				return RedirectToAction(nameof(Index));
			}
			return View(permission);
		}
		// GET: PermissionController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: PermissionController/Edit/5
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

		// GET: PermissionController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: PermissionController/Delete/5
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
