using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOICMS.Models
{
    public enum InsurerTypes { Auto, Home, Commercial, Other };
    public class InsurerCreate
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public InsurerTypes Type { get; set; }
    }
}
