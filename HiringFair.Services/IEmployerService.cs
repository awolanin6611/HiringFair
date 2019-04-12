using HiringFair.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringFair.Services
{
    public interface IEmployerService
    {
        bool CreateEmployer(EmployerCreate model);

        IEnumerable<EmployerListItem> GetEmployers();
        EmployerDetail GetEmployerById(int employerId);

        bool UpdateEmployer(EmployerEdit model);

        bool DeleteEmployer(int employerId);
    }
}
