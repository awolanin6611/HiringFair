using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringFair.Models
{
    public class EmployerListItem
    {
        public int EmployerId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLocation { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
