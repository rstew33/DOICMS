using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOICMS.Data
{
    public class Investigator
    {
        [Key] public int InvestigatorID { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Address { get; set; }
        [Required] public string PhoneNumber { get; set; }
        //Public virtual List<Complaint> ComplaintsInv[fk - Complaints]
        //Public virtual List<AdminAction> AdminActions[fk - AdminActions]

    }
}
