using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringFair.Models
{
    public class EmployerCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please Enter your Name.")]
        [MaxLength(128)]
        public string CompanyName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please Enter your Location")]
        [MaxLength(128)]
        public string CompanyLocation { get; set; }
    }
}
