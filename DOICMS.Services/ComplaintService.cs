using DOICMS.Data;
using DOICMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOICMS.Services
{
    public class ComplaintService
    {
        public bool ComplaintCreate(ComplaintCreate model)
        {
            var entity =
                new Complaint()
                {
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
                            AdminActionID = e.AdminActionID,
                            AgentID = e.AgentID,
                            InsurerID = e.InsurerID,
                            ConsumerID = e.ConsumerID,
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
