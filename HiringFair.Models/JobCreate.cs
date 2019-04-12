using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringFair.Models
{
    public class JobCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please Enter your Job Field.")]
        [MaxLength(128)]
        public string JobField { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please Enter the Job Title")]
        [MaxLength(128)]
        public string JobTitle { get; set; }
        
        public string JobDescription { get; set; }
        [Display(Name = "Employee Name")]
        public int EmployeeId { get; set; }
        [Display(Name = "CompanyName")]
        public int EmployerId { get; set; }
        public string CompanyName { get; set; }

    }
}
