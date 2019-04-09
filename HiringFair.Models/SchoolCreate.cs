using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringFair.Models
{
    public class SchoolCreate
    {
        [Required]
        [MinLength(2,ErrorMessage = "Please Enter the Full Name of your School.")]
        [MaxLength(128)]
        public string SchoolName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please Enter the Location of your School.")]
        [MaxLength(128)]
        public string SchoolLocation { get; set; }

        public int YearsAtSchool { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please Enter the Title of your Degree.")]
        [MaxLength(128)]
        public string TypeofDegree { get; set; }
    }
}
