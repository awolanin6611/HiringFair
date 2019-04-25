using HiringFair.Models;
using HiringFair.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HiringFair.API.Controllers
{
    public class EmployeesController : ApiController
    {
        //private readonly Lazy<IEmployeeService> _employeeService;

        //public EmployeesController()
        //{
        //    _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(Guid.Parse(User.Identity.GetUserId())));
        //}
        public IHttpActionResult GetAll()
        {
            EmployeeService employeeService = CreateEmployee();
            var employees = employeeService.GetEmployees();
            return Ok(employees);
        }
        public IHttpActionResult Get(int id)
        {
            EmployeeService employeeService = CreateEmployee();
            var employee = employeeService.GetEmployeeById(id);
            return Ok(employee);
        }

        public IHttpActionResult Post(EmployeeCreate employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEmployee();

            if (!service.CreateEmployee(employee))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Put(EmployeeEdit employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEmployee();

            if (!service.UpdateEmployee(employee))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateEmployee();

            if (!service.DeleteEmployee(id))
                return InternalServerError();

            return Ok();
        }
        private EmployeeService CreateEmployee()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var employeeService = new EmployeeService(userId);
            return employeeService;
        }
    }
}
