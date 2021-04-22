﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOICMS.Data
{
    public class Insurer
    {
            [Key]
            public int InsurerID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string PhoneNumber { get; set; }
            public enum _Type { Auto, Home, Commercial, Other };
            public _Type Type { get; set; }
        // public virtual List<Complaint> Complaints - fk of complaints - for each

    }
}
