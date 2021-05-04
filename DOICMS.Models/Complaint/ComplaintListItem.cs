using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOICMS.Models
{
    public class ComplaintListItem
    {
        public int ComplaintID { get; set; }
        public int InvestigatorID { get; set; }//[fk - Investigators]
        [Display(Name = "Investigator Name")]
        public string InvestigatorName { get; set; }
        public int? AdminActionID { get; set; } //[fk - AdminActions]
        [Display(Name = "Order Type")]
        public string OrderType { get; set; }
        public int? AgentID { get; set; }//[fk - Agents]
        [Display(Name = "Agent Name")]
        public string AgentName { get; set; }
        public int? InsurerID { get; set; }//[fk - Insurers]
        [Display(Name = "Insurer Name")]
        public string InsurerName { get; set; }
        public int? ConsumerID { get; set; } //[fk - Consumers]
        [Display(Name = "Consumer Name")]
        public string ConsumerName { get; set; }
        [Display(Name = "Complaint Desc")]
        public string ComplaintDesc { get; set; }
        public bool Resolved { get; set; }
        [Display(Name = "Date Submitted")]
        public DateTimeOffset DateSubmitted { get; set; }
        [Display(Name = "Date Completed")]
        public DateTimeOffset DateCompleted { get; set; }
    }
}
