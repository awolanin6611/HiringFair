using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringFair.Models
{
    public class JobDetail
    {
        public int JobId { get; set; }
        public string JobField { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        [Display(Name = "Employee Name")]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        [Display(Name = "CompanyName")]
        public int EmployerId { get; set; }
        public string CompanyName { get; set; }
        public string EmployeeName { get; set; }
        public string EmployerName { get; set; }
    }
}
