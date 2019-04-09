using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringFair.Models
{
    public class SchoolEdit
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string SchoolLocation { get; set; }
        public int YearsAtSchool { get; set; }
        public string TypeofDegree { get; set; }
    }
}
