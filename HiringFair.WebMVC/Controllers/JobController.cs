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
    public class JobController : Controller
    {
        private readonly Lazy<IJobService> _jobService;

        public JobController()
        {
            _jobService = new Lazy<IJobService>(CreateJobService);
        }
        public JobController(Lazy<IJobService> jobService)
        {
            _jobService = jobService;
        }
        // GET: Job
        public ActionResult Index()
        {
            var model = _jobService.Value.GetJobs();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            if (_jobService.Value.CreateJob(model))
            {
                TempData["SaveResult"] = "Here is the job you are looking for.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Invalid input try again");
            return View(model);
        }
        public ActionResult Detail(int id)
        {
            var model =
                _jobService.Value.GetJobById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var detail =
                _jobService.Value.GetJobById(id);
            var model =
                new JobEdit
                {
                    JobId = detail.JobId,
                    JobTitle = detail.JobTitle,
                    JobField = detail.JobField,
                    JobDescription = detail.JobDescription,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, JobEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.JobId != id)
            {
                ModelState.AddModelError("", "Id Mismatch.");
                return View(model);
            }
            if (_jobService.Value.UpdateJob(model))
            {
                TempData["SaveResult"] = "You successfully updated your account.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "You couldn't update your job search successfully.");
            return View(model);
        }
        public ActionResult Delete (int id)
        {
            var model =
                _jobService.Value.GetJobById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteJob(int id)
        {
            _jobService.Value.DeleteJob(id);

            TempData["SaveResult"] = "You successfully delete the job.";
            return RedirectToAction("Index");
        }
        private IJobService CreateJobService()
        {
            var jobId = Guid.Parse
                (User.Identity.GetUserId());
            var service = new JobService(jobId);
            return service;
        }
    }
}