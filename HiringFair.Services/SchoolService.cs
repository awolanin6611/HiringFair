using HiringFair.Data;
using HiringFair.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringFair.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly Guid _schoolId;
        public SchoolService(Guid schoolId)
        {
            _schoolId = schoolId;
        }

        public bool CreateSchool(SchoolCreate model)
        {
            var entity = new School
            {
                SchoolName = model.SchoolName,
                SchoolLocation = model.SchoolLocation,
                TypeOfDegree = model.TypeofDegree,
                YearsAtSchool = model.YearsAtSchool,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Schools.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SchoolListItem>
            GetSchools()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Employees
                    .Select(
                    e =>
                        new SchoolListItem
                        {
                            SchoolId = e.SchoolId,
                            SchoolName = e.SchoolName,
                            SchoolLocation = e.SchoolLocation,
                            TypeofDegree = e.TypeofDegree,
                            YearsAtSchool = e.YearsAtSchool,
                        }
                        );
                return query.ToArray();
            }
        }
        public SchoolDetail GetSchoolById(int schoolId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Schools
            }
        }

    }
}
