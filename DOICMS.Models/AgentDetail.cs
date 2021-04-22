﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOICMS.Models
{
    public class AgentDetail
    {
        public int AgentID { get; set; }
        public int LicenseNumber { get; set; }
        [Display(Name = "Agent Name")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
