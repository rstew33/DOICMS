﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOICMS.Models
{
    public class InvestigatorListItem
    {
        public int InvestigatorID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        //Public virtual List<Complaint> ComplaintsInv[fk - Complaints]
        //Public virtual List<AdminAction> AdminActions[fk - AdminActions]
    }
}
