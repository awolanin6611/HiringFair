using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringFair.Data
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        [Required]
        public string JobField { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string JobDescription { get; set; }

        public int EmployeeId { get; set; }

        public int EmployerId { get; set; }
        

        public virtual Employee Employee { get; set; }

        public virtual Employer Employer { get; set; }


    }
}
