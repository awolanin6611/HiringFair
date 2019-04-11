using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringFair.Data
{
    public class School
    {
        [Key]
        public int SchoolId { get; set; }
        [Required]
        public string SchoolName { get; set; }
        [Required]
        public string SchoolLocation { get; set; }
        [Required]
        public int YearsAtSchool { get; set; }
        [Required]
        public string TypeOfDegree { get; set; }
    }
}
