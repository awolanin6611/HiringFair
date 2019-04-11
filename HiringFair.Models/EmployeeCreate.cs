using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringFair.Models
{
    public class EmployeeCreate
    {
        [Required]
        [MinLength(2,ErrorMessage = "Please Enter your Name.")]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [MinLength(4,ErrorMessage = "Please type in your Sexual Orientation.")]
        [MaxLength(128)]
        public string Gender { get; set; }

        [Required]
        [MinLength(2,ErrorMessage = "Please Type in your Race.")]
        [MaxLength(128)]
        public string Race { get; set; }

        


    }
}
