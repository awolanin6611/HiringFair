using HiringFair.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringFair.Services
{
    public interface ISchoolService
    {
        bool CreateSchool(SchoolCreate model);
        IEnumerable<SchoolListItem> GetSchools();
        SchoolDetail GetSchoolById(int schoolId);
        bool UpdateSchool(SchoolEdit model);
        bool DeleteSchool(int schoolId);

    }
}
