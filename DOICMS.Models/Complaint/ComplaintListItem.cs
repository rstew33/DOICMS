using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOICMS.Models
{
    public class ComplaintListItem
    {
        public int ComplaintID { get; set; }
        public int InvestigatorID { get; set; }//[fk - Investigators]
        public string InvestigatorName { get; set; }
        public int? AdminActionID { get; set; } //[fk - AdminActions]
        public string OrderType { get; set; }
        public int? AgentID { get; set; }//[fk - Agents]
        public string AgentName { get; set; }
        public int? InsurerID { get; set; }//[fk - Insurers]
        public string InsurerName { get; set; }
        public int? ConsumerID { get; set; } //[fk - Consumers]
        public string ConsumerName { get; set; }
        public string ComplaintDesc { get; set; }
        public bool Resolved { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime DateCompleted { get; set; }
    }
}
