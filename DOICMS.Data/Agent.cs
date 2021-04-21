using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOICMS.Data
{
    public class Agent
    {
        [Key]
        public int AgentID { get; set; }
        [Required] 
        public int LicenseNumber { get; set; }
        [Required] 
        [Display(Name = "Agent Name")]
        public string Name { get; set; }
        [Required] 
        public string Email { get; set; }
        [Required] 
        public string Address { get; set; }
        [Required] 
        public string PhoneNumber { get; set; }
        //public virtual List<Insurer> Appointments[fk - Insurers]
        //public virtual List<Complaint> ComplaintsAgents[fk - Complaints]

    }
}
