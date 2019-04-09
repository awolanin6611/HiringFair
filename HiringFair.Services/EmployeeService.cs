using HiringFair.Data;
using HiringFair.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringFair.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly Guid _employeeId;
        public EmployeeService(Guid employeeId)
        {
            _employeeId = employeeId;
        }

        public bool CreateEmployee(EmployeeCreate model)
        {
            var entity = new Employee
            {
                Name = model.Name,
                Age = model.Age,
                Gender = model.Gender,
                Race = model.Race
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Employees.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<EmployeeListItem>
            GetEmployees()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Employees
                        .Select(
                        e =>
                            new EmployeeListItem
                            {
                                EmployeeId = e.EmployeeId,
                                Name = e.Name,
                                Age = e.Age,
                                Gender = e.Gender,
                                Race = e.Race,
                            }
                        );
                return query.ToArray();
            }
        }

        public EmployeeDetail GetEmployeeById(int employeeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Employees
                    .Single(e => e.EmployeeId == employeeId);

                return
                    new EmployeeDetail
                    {
                        EmployeeId = entity.EmployeeId,
                        Name = entity.Name,
                        Age = entity.Age,
                        Gender = entity.Gender,
                        Race = entity.Race,
                    };
            }
        }

        public bool UpdateEmployee(EmployeeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Employees
                    .Single(e => e.EmployeeId == model.EmployeeId);
                entity.EmployeeId = model.EmployeeId;
                entity.Name = model.Name;
                entity.Age = model.Age;
                entity.Gender = model.Gender;
                entity.Race = model.Race;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEmployee(int employeeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Employees
                    .Single(e => e.EmployeeId == employeeId);

                ctx.Employees.Remove(entity);

                return ctx.SaveChanges() == 1;


            }
        }
    }
}
