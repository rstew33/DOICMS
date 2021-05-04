using DOICMS.Data;
using DOICMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DOICMS.Services
{
    public class ComplaintService
    {
        public IEnumerable<SelectListItem> GetAllInvestigators()
        {
            var ctx = new ApplicationDbContext();
            IEnumerable<SelectListItem> list = from s in ctx.Investigators
                                               select new SelectListItem
                                               {
                                                   Selected = false,
                                                   Text = s.Name,
                                                   Value = s.InvestigatorID.ToString()
                                               };
            return list;
        }
        public IEnumerable<SelectListItem> GetAllAgents()
        {
            var ctx = new ApplicationDbContext();
            IEnumerable<SelectListItem> list = from s in ctx.Agents
                                               select new SelectListItem
                                               {
                                                   Selected = false,
                                                   Text = s.Name,
                                                   Value = s.AgentID.ToString()
                                               };
            return list;
        }
        public IEnumerable<SelectListItem> GetAllAdmin()
        {
            var ctx = new ApplicationDbContext();
            IEnumerable<SelectListItem> list = from s in ctx.AdminActions
                                               select new SelectListItem
                                               {
                                                   Selected = false,
                                                   Text = s.AdminActionID.ToString(),
                                                   Value = s.AdminActionID.ToString()
                                               };
            return list;
        }
        public IEnumerable<SelectListItem> GetAllInsurer()
        {
            var ctx = new ApplicationDbContext();
            IEnumerable<SelectListItem> list = from s in ctx.Insurers
                                               select new SelectListItem
                                               {
                                                   Selected = false,
                                                   Text = s.Name,
                                                   Value = s.InsurerID.ToString()
                                               };
            return list;
        }
        public IEnumerable<SelectListItem> GetAllConsumer()
        {
            var ctx = new ApplicationDbContext();
            IEnumerable<SelectListItem> list = from s in ctx.Consumers
                                               select new SelectListItem
                                               {
                                                   Selected = false,
                                                   Text = s.Name,
                                                   Value = s.ConsumerID.ToString()
                                               };
            return list;
        }
        public bool ComplaintCreate(ComplaintCreate model)
        {
            var entity =
                new Complaint()
                {
                    InvestigatorID = model.InvestigatorID,
                    AdminActionID = model.AdminActionID,
                    AgentID = model.AgentID,
                    InsurerID = model.InsurerID,
                    ConsumerID = model.ConsumerID,
                    ComplaintDesc = model.ComplaintDesc,
                    Resolved = model.Resolved,
                    DateSubmitted = model.DateSubmitted,
                    DateCompleted = model.DateCompleted
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Complaints.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ComplaintListItem> GetComplaints()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Complaints
                    .Select(
                        e =>
                        new ComplaintListItem
                        {
                            ComplaintID = e.ComplaintID,
                            InvestigatorID = e.InvestigatorID,
                            InvestigatorName = e.Investigator.Name,
                            AdminActionID = e.AdminActionID,
                            OrderType = e.AdminAction.OrderType,
                            AgentID = e.AgentID,
                            AgentName = e.Agent.Name,
                            InsurerID = e.InsurerID,
                            InsurerName = e.Insurer.Name,
                            ConsumerID = e.ConsumerID,
                            ConsumerName = e.Consumer.Name,
                            ComplaintDesc = e.ComplaintDesc,
                            Resolved = e.Resolved,
                            DateSubmitted = e.DateSubmitted,
                            DateCompleted = e.DateCompleted
                        }
                        );

                return query.ToArray();
            }
        }
        public ComplaintDetail GetComplaintByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Complaints
                        .Single(e => e.ComplaintID == id);
                return
                    new ComplaintDetail
                    {
                        InvestigatorID = entity.InvestigatorID,
                        ComplaintID = entity.ComplaintID,
                        AdminActionID = entity.AdminActionID,
                        AgentID = entity.AgentID,
                        InsurerID = entity.InsurerID,
                        ConsumerID = entity.ConsumerID,
                        ComplaintDesc = entity.ComplaintDesc,
                        Resolved = entity.Resolved,
                        DateSubmitted = entity.DateSubmitted,
                        DateCompleted = entity.DateCompleted
                    };

            }
        }
        public bool UpdateComplaint(ComplaintEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Complaints
                        .Single(e => e.ComplaintID == model.ComplaintID);
                entity.InvestigatorID = model.InvestigatorID;
                entity.AgentID = model.AgentID;
                entity.InsurerID = model.InsurerID;
                entity.ConsumerID = model.ConsumerID;
                entity.ComplaintDesc = model.ComplaintDesc;
                entity.Resolved = model.Resolved;
                entity.DateSubmitted = model.DateSubmitted;
                entity.DateCompleted = model.DateCompleted;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteComplaint(int ComplaintID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Complaints
                        .Single(e => e.ComplaintID == ComplaintID);

                ctx.Complaints.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
