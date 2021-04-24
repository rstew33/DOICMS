using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOICMS.Models
{
    public class AdminActionEdit
    {
        public int AdminActionID { get; set; }
        public string OrderType { get; set; }
        public int InvestigatorID { get; set; } //[fk - Investigators]
        public int? AgentID { get; set; } //nullable
        public int? InsurerID { get; set; } //nullable
    }
}
