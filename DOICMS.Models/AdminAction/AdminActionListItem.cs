using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOICMS.Models
{
    public class AdminActionListItem
    {
        public int AdminActionID { get; set; }
        [Display(Name = "Order Type")]
        public string OrderType { get; set; }
        public int InvestigatorID { get; set; } //[fk - Investigators]
        public string InvestigatorName { get; set; }
        public int? AgentID { get; set; } //nullable
        public int? InsurerID { get; set; } //nullable
    }
}
