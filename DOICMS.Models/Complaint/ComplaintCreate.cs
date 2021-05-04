using DOICMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DOICMS.Models
{
    public class ComplaintCreate
    {
        public int InvestigatorID { get; set; }//[fk - Investigators]
        public int? AdminActionID { get; set; } //[fk - AdminActions]
        public int? AgentID { get; set; }//[fk - Agents]
        public int? InsurerID { get; set; }//[fk - Insurers]
        public int? ConsumerID { get; set; } //[fk - Consumers]
        [Display(Name = "Complaint Desc")]
        public string ComplaintDesc { get; set; }
        public bool Resolved { get; set; }
        [Display(Name = "Date Submitted")]
        public DateTimeOffset DateSubmitted { get; set; }
        [Display(Name = "Date Completed")]
        public DateTimeOffset DateCompleted { get; set; }
        public IEnumerable<SelectListItem> InvestigatorList {get; set;}
        public IEnumerable<SelectListItem> AdminList { get; set; }
        public IEnumerable<SelectListItem> AgentList { get; set; }
        public IEnumerable<SelectListItem> InsurerList { get; set; }
        public IEnumerable<SelectListItem> ConsumerList { get; set; }
    }
}
