using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOICMS.Data
{
    public class Complaint
    {
        [Key] 
        public int ComplaintID { get; set; }
        public int InvestigatorID { get; set; }//[fk - Investigators]
        public int? AdminActionID { get; set; } //[fk - AdminActions]
        public int? AgentID { get; set; }//[fk - Agents]
        public int? InsurerID { get; set; }//[fk - Insurers]
        public int? ConsumerID { get; set; } //[fk - Consumers]
        public string ComplaintDesc { get; set; }
        public bool Resolved { get; set; }
        [Required] 
        public DateTime DateSubmitted { get; set; }
        public DateTime DateCompleted { get; set; }
    }
}
