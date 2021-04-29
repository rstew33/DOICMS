using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOICMS.Data
{
    public class AdminAction
    {
    [Key] public int AdminActionID { get; set; }
    [Required] 
    public string OrderType { get; set; }
    [Required] 
    [ForeignKey("Investigator")]
    public int InvestigatorID { get; set; } //[fk - Investigators]
    public virtual Investigator Investigator { get; set; }
    public int? AgentID { get; set; } //nullable
    public int? InsurerID { get; set; } //nullable
    //public int? ComplaintID { get; set; }

    }
}
