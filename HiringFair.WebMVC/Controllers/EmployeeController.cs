using HiringFair.Models;
using HiringFair.Services;
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HiringFair.WebMVC.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly Lazy<IEmployeeService> _employeeService;

        public EmployeeController()
        {
            _employeeService = new Lazy<IEmployeeService>(CreateEmployeeService);
        }
        public EmployeeController(Lazy<IEmployeeService> employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: Employee
        public ActionResult Index()
        {
            var model = _employeeService.Value.GetEmployees();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            if (_employeeService.Value.CreateEmployee(model))
            {
                TempData["SaveResult"] = "Here is you.";
                    return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Invaild Input try again");
            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var model = _employeeService.Value.GetEmployeeById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var detail = _employeeService.Value.GetEmployeeById(id);
            var model =
            new EmployeeEdit
            {
                EmployeeId = detail.EmployeeId,
                Name = detail.Name,
                Age = detail.Age,
                Gender = detail.Gender,
                Race = detail.Race,
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.EmployeeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            if (_employeeService.Value.UpdateEmployee(model))
            {
                TempData["SaveResult"] = "You Succesfully updated your account.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "You couldn't successfully update your account.");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var model = _employeeService.Value.GetEmployeeById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEmployee (int id)
        {
            _employeeService.Value.DeleteEmployee(id);

            TempData["SaveResult"] = "You have been successfully deleted.";

            return RedirectToAction("Index");
        }
        private IEmployeeService CreateEmployeeService()
        {
            var employeeId = Guid.Parse(User.Identity.GetUserId());
            var service = new EmployeeService(employeeId);
            return service;
        }
    }
}