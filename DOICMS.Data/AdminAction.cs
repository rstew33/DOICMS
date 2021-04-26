using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOICMS.Data
{
    public class AdminAction
    {
    [Key] public int AdminActionID { get; set; }
    [Required] public string OrderType { get; set; }
    [Required] public int InvestigatorID { get; set; } //[fk - Investigators]
    public int? AgentID { get; set; } //nullable
    public int? InsurerID { get; set; } //nullable
    //public int? ComplaintID { get; set; }

    }
}
