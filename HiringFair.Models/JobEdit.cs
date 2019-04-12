using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringFair.Models
{
    public class JobEdit
    {
        public int JobId { get; set; }
        public string JobField { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployerId { get; set; }
        public string EmployerName { get; set; }
    }
}
