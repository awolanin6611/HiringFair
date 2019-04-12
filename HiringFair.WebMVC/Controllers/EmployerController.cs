using HiringFair.Models;
using HiringFair.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HiringFair.WebMVC.Controllers
{
    public class EmployerController : Controller
    {
        private readonly Lazy<IEmployerService> _employerService;

        public EmployerController()
        {
            _employerService = new Lazy<IEmployerService>(CreateEmployerService);
        }
        public EmployerController(Lazy<IEmployerService> employerService)
        {
            _employerService = employerService;
        }
        // GET: Employer
        public ActionResult Index()
        {
            var model = _employerService.Value.GetEmployers();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployerCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            if (_employerService.Value.CreateEmployer(model))
            {
                TempData["SaveResult"] = "Here is your Company.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Invalid input try again");
            return View(model);
        }
        public ActionResult Detail(int id)
        {
            var model =
                _employerService.Value.GetEmployerById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var detail =
                _employerService.Value.GetEmployerById(id);
            var model =
                new EmployerEdit
                {
                    EmployerId = detail.EmployerId,
                    CompanyName = detail.CompanyName,
                    CompanyLocation = detail.CompanyLocation,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployerEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.EmployerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            if (_employerService.Value.UpdateEmployer(model))
            {
                TempData["SaveResult"] = "You Successfully Updated your Company";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "You couldn't update your Company info");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var model =
                _employerService.Value.GetEmployerById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEmployer(int id)
        {
            _employerService.Value.DeleteEmployer(id);

            TempData["SaveResult"] = "You successfully deleted your Company.";

                    return RedirectToAction("Index");

        }
        private IEmployerService CreateEmployerService()
        {
            var employerId = Guid.Parse
                (User.Identity.GetUserId());
            var service = new EmployerService(employerId);
            return service;
        }

    }
}