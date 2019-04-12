using HiringFair.Data;
using HiringFair.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringFair.Services
{
    public class EmployerService : IEmployerService
    {
        private readonly Guid _employerId;
        public EmployerService(Guid employerId)
        {
            _employerId = employerId;
        }
        public bool CreateEmployer(EmployerCreate model)
        {
            var entity = new Employer
            {
                CompanyName = model.CompanyName,
                CompanyLocation = model.CompanyLocation,

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Employers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<EmployerListItem>
            GetEmployers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Employers
                    .Select(
                        e =>
                    new EmployerListItem
                    {
                        EmployerId = e.EmployerId,
                        CompanyName = e.CompanyName,
                        CompanyLocation = e.CompanyLocation,
                    }
                    );
                return query.ToArray();
            }
        }
        public EmployerDetail GetEmployerById(int employerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Employers
                    .Single(e => e.EmployerId == employerId);
                return
                    new EmployerDetail
                    {
                        EmployerId = entity.EmployerId,
                        CompanyName = entity.CompanyName,
                        CompanyLocation = entity.CompanyLocation,
                    };
            }
        }
        public bool UpdateEmployer(EmployerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Employers
                    .Single(e => e.EmployerId == model.EmployerId);
                entity.EmployerId = model.EmployerId;
                entity.CompanyName = model.CompanyName;
                entity.CompanyLocation = model.CompanyLocation;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteEmployer(int employerId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Employers
                    .Single(e => e.EmployerId == employerId);

                ctx.Employers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
