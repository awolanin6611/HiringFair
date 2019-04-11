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
                    .Schools
                    .Select(
                    e =>
                        new SchoolListItem
                        {
                            SchoolId = e.SchoolId,
                            SchoolName = e.SchoolName,
                            SchoolLocation = e.SchoolLocation,
                            TypeofDegree = e.TypeOfDegree,
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
                    .Single(e => e.SchoolId == schoolId);

                return
                    new SchoolDetail
                    {
                        SchoolId = entity.SchoolId,
                        SchoolName = entity.SchoolName,
                        SchoolLocation = entity.SchoolLocation,
                        TypeofDegree = entity.TypeOfDegree,
                        YearsAtSchool = entity.YearsAtSchool,
                    };
            }
        }

        public bool UpdateSchool(SchoolEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Schools
                    .Single(e => e.SchoolId == model.SchoolId);
                    entity.SchoolId = model.SchoolId;
                entity.SchoolName = model.SchoolName;
                entity.SchoolLocation = model.SchoolLocation;
                entity.TypeOfDegree = model.TypeofDegree;
                entity.YearsAtSchool = model.YearsAtSchool;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSchool(int schoolId)
        {
            using (var ctx =  new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Schools
                    .Single(e => e.SchoolId == schoolId);

                ctx.Schools.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
