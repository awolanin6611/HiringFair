using HiringFair.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringFair.Services
{
    public interface IEmployeeService
    {
        bool CreateEmployee(EmployeeCreate model);

        IEnumerable<EmployeeListItem> GetEmployees();
        EmployeeDetail GetEmployeeById(int employeeId);

        bool UpdateEmployee(EmployeeEdit model);

        bool DeleteEmployee(int employeeId);
    }
}
