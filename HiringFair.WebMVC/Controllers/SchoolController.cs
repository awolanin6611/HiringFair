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
    [Authorize]
    public class SchoolController : Controller
    {
        private readonly Lazy<ISchoolService> _schoolService;
        public SchoolController()
        {
            _schoolService = new Lazy<ISchoolService>(CreateSchoolService);
        }
        public SchoolController(Lazy<ISchoolService> schoolService)
        {
            _schoolService = schoolService;
        }
        // GET: School
        public ActionResult Index()
        {
            var model = _schoolService.Value.GetSchools();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SchoolCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            if (_schoolService.Value.CreateSchool(model))
            {
                TempData["SaveResult"] =  "Here is your school."; return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Invalid Input try again");
            return View(model);
        }
        public ActionResult Detail(int id)
        {
            var model =
                _schoolService.Value.GetSchoolById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var detail =
                _schoolService.Value.GetSchoolById(id);
            var model =
                new SchoolEdit
                {
                    SchoolId = detail.SchoolId,
                    SchoolName = detail.SchoolName,
                    SchoolLocation = detail.SchoolLocation,
                    TypeofDegree = detail.TypeofDegree,
                    YearsAtSchool = detail.YearsAtSchool,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SchoolEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.SchoolId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            if (_schoolService.Value.UpdateSchool(model))
            {
                TempData["SaveResult"] = "You successfully updated your school.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "You couldn't successfully update your school info.");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var model =
                _schoolService.Value.GetSchoolById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSchool (int id)
        {
            _schoolService.Value.DeleteSchool(id);

            TempData["SaveResult"] = "You have successfully deleted your school.";

            return RedirectToAction("Index");
        }
        private ISchoolService CreateSchoolService()
        {
            var schoolId = Guid.Parse
                (User.Identity.GetUserId());
            var service = new SchoolService(schoolId);
            return service;
        }
    }
}