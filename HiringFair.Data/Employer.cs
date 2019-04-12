using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringFair.Data
{
    public class Employer
    {
        [Key]
        public int EmployerId { get; set; }

        public string CompanyName { get; set; }
        public string CompanyLocation { get; set; }

        
    }
}
