using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOICMS.Data
{
    public class Complaint
    {
        [Key] 
        public int ComplaintID { get; set; }
        [ForeignKey("Investigator")]
        public int InvestigatorID { get; set; }//[fk - Investigators]
        public virtual Investigator Investigator { get; set; }
        [ForeignKey("AdminAction")]
        public int? AdminActionID { get; set; } //[fk - AdminActions]
        public virtual AdminAction AdminAction { get; set; }
        [ForeignKey("Agent")]
        public int? AgentID { get; set; }//[fk - Agents]
        public virtual Agent Agent { get; set; }
        [ForeignKey("Insurer")]
        public int? InsurerID { get; set; }//[fk - Insurers]
        public virtual Insurer Insurer { get; set; }
        [ForeignKey("Consumer")]
        public int? ConsumerID { get; set; } //[fk - Consumers]
        public virtual Consumer Consumer { get; set; }
        public string ComplaintDesc { get; set; }
        public bool Resolved { get; set; }
        [Required] 
        public DateTime DateSubmitted { get; set; }
        public DateTime DateCompleted { get; set; }
    }
}
