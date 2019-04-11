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
    }
}
